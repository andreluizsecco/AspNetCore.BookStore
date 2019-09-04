namespace AspNetCore.Bookstore.Domain.Commands
{
    public class UpdateBookCommand : BookCommand
    {
        public UpdateBookCommand() { }
        public UpdateBookCommand(int id, string title, string author, string category, int quantity, decimal price)
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