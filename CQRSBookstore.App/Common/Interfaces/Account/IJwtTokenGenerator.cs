using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Common.Interface.Account;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
