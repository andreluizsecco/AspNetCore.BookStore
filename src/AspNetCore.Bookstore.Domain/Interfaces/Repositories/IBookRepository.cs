using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Domain.Entities;

namespace AspNetCore.Bookstore.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> FindBooksByAuthor(string author);
        Task<Book> GetByTitle(string title);
    }
}