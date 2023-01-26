using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Common.interfaces.Account;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
