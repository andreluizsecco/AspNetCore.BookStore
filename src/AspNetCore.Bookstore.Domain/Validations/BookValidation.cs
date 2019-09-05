using AspNetCore.Bookstore.Domain.Commands;
using FluentValidation;

namespace AspNetCore.Bookstore.Domain.Validations
{
    public class BookValidation : AbstractValidator<BookCommand>
    {
        public void ValidateID()
        {
            RuleFor(p => p.ID)
                .GreaterThan(0).WithMessage("The ID must be greater than zero");
        }

        public void ValidateTitle()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("The Title cannot be empty")
                .MaximumLength(150).WithMessage("The Title must be a maximum of 150 characters");
        }

        public void ValidateAuthor()
        {
            RuleFor(p => p.Author)
                .NotEmpty().WithMessage("The Author cannot be empty")
                .MaximumLength(150).WithMessage("The Author must be a maximum of 150 characters");
        }

        public void ValidateCategory()
        {
            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("The Category cannot be empty")
                .MaximumLength(150).WithMessage("The Category must be a maximum of 150 characters");
        }

        public void ValidateQuantity()
        {
            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("The Quantity must be greater than zero");
        }
        
        public void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("The Price must be greater than zero");
        }
    }
}