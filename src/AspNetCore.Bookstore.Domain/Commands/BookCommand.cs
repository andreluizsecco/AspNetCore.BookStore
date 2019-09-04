using AspNetCore.Bookstore.Domain.Interfaces.Commands;
using AspNetCore.Bookstore.Domain.Validations;
using FluentValidation.Results;
using MediatR;

namespace AspNetCore.Bookstore.Domain.Commands
{
    public abstract class BookCommand : IRequest<Result>, ICommand
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            var validation = new BookValidation();
            validation.ValidateID();
            validation.ValidateTitle();
            validation.ValidateAuthor();
            validation.ValidateCategory();
            validation.ValidateQuantity();
            validation.ValidatePrice();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}