namespace CQRSBookstore.App.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
}
