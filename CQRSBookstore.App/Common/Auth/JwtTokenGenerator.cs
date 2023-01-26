using CQRSBookstore.App.Common.interfaces.Account;
using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Common.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }
}
