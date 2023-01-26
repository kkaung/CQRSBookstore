using MediatR;
using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Commands.Book;

public record CreateReservationCommand(Guid UserId, Guid BookId) : IRequest<Reservation>;
