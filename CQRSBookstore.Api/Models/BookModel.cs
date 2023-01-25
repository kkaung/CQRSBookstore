namespace CQRSBookstore.App.Models;

public class BookModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public string ISBN { get; set; } = String.Empty;
    public DateTime? PublishedAt { get; set; }
}
