using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Common.Interface.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetBooks();

    Task<Book?> GetBookById(Guid id);

    Task<List<Book>> GetBooksByName(string search);
}
