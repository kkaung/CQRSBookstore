namespace CQRSBookstore.Api.Contracts.Account;

public record RegisterRequest(string Username, string Email, string Password);
