using MediatR;
using CQRSBookstore.App.Common.interfaces.Repositories;

namespace CQRSBookstore.App.Queries.Book;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Models.Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<Models.Book>> Handle(
        GetBooksQuery request,
        CancellationToken cancellationToken
    )
    {
        Console.WriteLine("Handlers");
        return await _bookRepository.GetBooks();
    }
}
