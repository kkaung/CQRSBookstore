using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Common.interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);

    Task AddUser(User user);
}
