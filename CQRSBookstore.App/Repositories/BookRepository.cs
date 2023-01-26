using CQRSBookstore.App.Common.interfaces.Repositories;
using CQRSBookstore.App.Data;
using CQRSBookstore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSBookstore.App.Repositories;

public class BookRepository : IBookRepository
{
    private readonly DataContext _context;

    public BookRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Book?> GetBookById(Guid id)
    {
        return await _context.Books!.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _context.Books!.ToListAsync();
    }
    
    public async Task<List<Book>> GetBooksByName(string search)
    {
        return await _context.Books!.Where(b => b.Title.Contains(search)).ToListAsync();
    }
}
