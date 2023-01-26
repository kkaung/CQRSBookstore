namespace CQRSBookstore.App.Models;

public class Reservation
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
    public DateTime PickupDate { get; set; } = DateTime.UtcNow;
    public User? User { get; set; }
    public Book? Book { get; set; }
}
