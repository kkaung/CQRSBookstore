namespace CQRSBookstore.App.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public Int64 ISBN { get; set; }
    public  DateTime?  PublishedAt { get; set; }
}


