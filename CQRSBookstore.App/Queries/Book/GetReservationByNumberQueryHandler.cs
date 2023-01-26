using CQRSBookstore.App.Common.interfaces.Repositories;
using MediatR;

namespace CQRSBookstore.App.Queries.Book;

public class GetReservationByNumberQueryHandler
    : IRequestHandler<GetReservationByNumberQuery, Models.Reservation>
{
    private IReservationsRepository _reservationsRepository;

    public GetReservationByNumberQueryHandler(IReservationsRepository reservationsRepository)
    {
        _reservationsRepository = reservationsRepository;
    }

    public async Task<Models.Reservation?> Handle(
        GetReservationByNumberQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _reservationsRepository.GetReservationByNumber(request.Number);
    }
}
