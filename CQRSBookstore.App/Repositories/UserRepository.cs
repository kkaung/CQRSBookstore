using CQRSBookstore.App.Common.interfaces.Repositories;
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


}
