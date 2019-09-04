namespace AspNetCore.Bookstore.Domain.Commands
{
    public class CreateBookCommand : BookCommand
    {
        public CreateBookCommand() { }
        public CreateBookCommand(int id, string title, string author, string category, int quantity, decimal price)
        {
            ID = id;
            Title = title;
            Author = author;
            Category = category;
            Quantity = quantity;
            Price = price;
        }
    }
}