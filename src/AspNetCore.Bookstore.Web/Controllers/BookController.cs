using AspNetCore.Bookstore.Domain;
using AspNetCore.Bookstore.Domain.Commands;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Bookstore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository,
                              IMediator mediator,
                              IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index() =>
            View(await _bookRepository.GetAll());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _bookRepository.GetById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        public IActionResult Create() =>
            View();
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookCommand request)
        {
            var result = await _mediator.Send(request);
            return Result(request, result);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _bookRepository.GetById(id);
            if (book == null)
                return NotFound();
                
            var command = _mapper.Map<UpdateBookCommand>(book);
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBookCommand request)
        {
            var result = await _mediator.Send(request);
            return Result(request, result);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _bookRepository.GetById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Book book)
        {
            var request = new DeleteBookCommand(book.ID);
            var result = await _mediator.Send(request);
            return Result(request, result);
        }

        private IActionResult Result(BookCommand request, Result result)
        {
            if (result.HasErrors)
            {
                result.Errors.ToList().ForEach(err => ModelState.AddModelError(string.Empty, err));
                return View(request);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
