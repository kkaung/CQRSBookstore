using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Common.Interface.Repositories;

public interface IReservationsRepository
{
    Task<Reservation?> GetReservationByNumber(int number);

    Task AddReservation(Reservation reservation);

    Task<Reservation?> GetReservationByUserId(Guid userId);

    Task<Reservation?> GetReservationByBookId(Guid bookId);
}
