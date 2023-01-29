using CQRSBookstore.App.Common.Interface.Repositories;
using CQRSBookstore.App.Data;
using CQRSBookstore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSBookstore.App.Repositories;

public class UserRepository : IUserRepository
{
    private DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        _context.Users!.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users!.Where(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _context.Users!.FirstOrDefaultAsync(u => u.Id == id);
    }
}
