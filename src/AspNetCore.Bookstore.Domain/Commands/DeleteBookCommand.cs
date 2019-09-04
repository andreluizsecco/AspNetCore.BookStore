using AspNetCore.Bookstore.Domain.Validations;

namespace AspNetCore.Bookstore.Domain.Commands
{
    public class DeleteBookCommand : BookCommand
    {
        public DeleteBookCommand(int id) =>
            ID = id;

        public override bool IsValid()
        {
            var validation = new BookValidation();
            validation.ValidateID();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}