using MediatR;

namespace CQRSBookstore.App.Queries.Book;

public record GetReservationByNumberQuery(int Number) : IRequest<Models.Reservation>;
