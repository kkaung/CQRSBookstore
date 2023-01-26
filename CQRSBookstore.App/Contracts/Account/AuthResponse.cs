namespace CQRSBookstore.App.Constracts.Account;

public record AuthResponse(Guid Id, string Username, string Email, string Token);

