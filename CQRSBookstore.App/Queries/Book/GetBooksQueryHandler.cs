using MediatR;
using CQRSBookstore.App.Common.Interface.Repositories;

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
        return await _bookRepository.GetBooks();
    }
}
