using AspNetCore.Bookstore.Data.Mappings;
using AspNetCore.Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Bookstore.Data.Context
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfiguration(new BookMap());

        public DbSet<Book> Books {get; set; }
    }
}