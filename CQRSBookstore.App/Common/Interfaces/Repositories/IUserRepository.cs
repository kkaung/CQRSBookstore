using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Common.Interface.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid id);

    Task AddUser(User user);
}
