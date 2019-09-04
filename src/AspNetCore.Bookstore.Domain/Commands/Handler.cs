using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using AspNetCore.Bookstore.Domain.Notifications;
using MediatR;

namespace AspNetCore.Bookstore.Domain.Commands
{
    public class Handler : IRequestHandler<CreateBookCommand, Result>,
                           IRequestHandler<UpdateBookCommand, Result>,
                           IRequestHandler<DeleteBookCommand, Result>
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository _bookRepository;

        public Handler(IMediator mediator,
                       IBookRepository bookRepository)
        {
            _mediator = mediator;
            _bookRepository = bookRepository;
        }

        private IEnumerable<string> GetErrors(BookCommand request) =>
            request.ValidationResult.Errors.Select(err => err.ErrorMessage);

        public async Task<Result> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
                if (await _bookRepository.GetById(request.ID) == null)
                    await _bookRepository.Add(
                        new Book(request.ID, request.Title, request.Author, request.Category, request.Quantity, request.Price)
                    );
                else
                {
                    var message = "The Book ID already exists.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult), cancellationToken);
                result.AddErrors(GetErrors(request));
            }
            return result;
        }

        public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var book = await _bookRepository.GetById(request.ID);
                if (book != null)
                {
                    book.Title = request.Title;
                    book.Author = request.Author;
                    book.Category = request.Category;
                    book.Quantity = request.Quantity;
                    book.Price = request.Price;
                    await _bookRepository.Update(book);
                }
                else
                {
                    var message = "The book cannot be found.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult), cancellationToken);
                result.AddErrors(GetErrors(request));
            }
            return result;
        }

        public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var book = await _bookRepository.GetById(request.ID);
                if (book != null)
                    await _bookRepository.Remove(book);
                else
                {
                    var message = "The book cannot be found.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult), cancellationToken);
                result.AddErrors(GetErrors(request));
            }

            return result;
        }
    }
}