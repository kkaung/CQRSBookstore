using CQRSBookstore.App.Common.Interface.Repositories;
using CQRSBookstore.App.Models;
using MediatR;

namespace CQRSBookstore.App.Commands.Book;

public class CreateReservationCommandHandler
    : IRequestHandler<CreateReservationCommand, Reservation>
{
    private IReservationsRepository _reservationRepository;
    private IBookRepository _bookRepository;
    private IUserRepository _userRepository;

    public CreateReservationCommandHandler(
        IReservationsRepository reservationRepository,
        IBookRepository bookRepository,
        IUserRepository userRepository
    )
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public async Task<Reservation> Handle(
        CreateReservationCommand request,
        CancellationToken cancellationToken
    )
    {
        // check the reservation has been created
        if (await _reservationRepository.GetReservationByBookId(request.BookId) is not null)
        {
            throw new Exception("Reservation already exists");
        }

        var book = await _bookRepository.GetBookById(request.BookId);

        var reservation = new Reservation()
        {
            Id = Guid.NewGuid(),
            Book = await _bookRepository.GetBookById(request.BookId),
            User = await _userRepository.GetUserById(request.UserId),
        };

        await _reservationRepository.AddReservation(reservation);

        return reservation;
    }
}
