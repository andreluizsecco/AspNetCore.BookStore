namespace AspNetCore.Bookstore.Domain.Interfaces.Commands
{
    public interface ICommand
    {
         bool IsValid();
    }
}