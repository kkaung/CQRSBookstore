using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Constracts.Account;

public record AuthResult(User User, string Token);
