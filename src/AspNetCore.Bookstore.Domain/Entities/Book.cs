using System;

namespace AspNetCore.Bookstore.Domain.Entities
{
    public class Book
    {
        public Book() =>
            CreatedDate = DateTime.Now;

        public Book(int id, string title, string author, string category, int quantity, decimal price) : this()
        {
            ID = id;
            Title = title;
            Author = author;
            Category = category;
            Quantity = quantity;
            Price = price;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}