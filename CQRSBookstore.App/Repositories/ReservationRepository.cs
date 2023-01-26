using CQRSBookstore.App.Common.interfaces.Repositories;
using CQRSBookstore.App.Data;
using CQRSBookstore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSBookstore.App.Repositories;

public class ReservationsRepository : IReservationsRepository
{
    private DataContext _context;

    public ReservationsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetReservationByNumber(int number)
    {
        return await _context.Reservations
            .Include(r => r.User)
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.Number == number);
    }

    public async Task<Reservation?> GetReservationByUserId(Guid userId)
    {
        return await _context.Reservations
            .Include(r => r.User)
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.User!.Id == userId);
    }

    public async Task AddReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task<Reservation?> GetReservationByBookId(Guid bookId)
    {
        return await _context.Reservations
            .Include(r => r.User)
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.Book!.Id == bookId);
    }
}
