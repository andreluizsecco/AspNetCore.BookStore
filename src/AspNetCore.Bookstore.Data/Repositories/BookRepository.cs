using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Data.Context;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Bookstore.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext context) : base(context) { }

        public async Task<IEnumerable<Book>> FindBooksByAuthor(string author) =>
            await db.Books
                .Where(b => EF.Functions.Like(b.Author, $"%{author}%"))
                .ToListAsync();

        public async Task<Book> GetByTitle(string title) =>
            await db.Books
                .FirstOrDefaultAsync(b => b.Title.Equals(title));
    }
}