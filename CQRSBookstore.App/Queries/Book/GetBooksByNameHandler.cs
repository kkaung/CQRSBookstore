using MediatR;
using CQRSBookstore.App.Common.interfaces.Repositories;

namespace CQRSBookstore.App.Queries.Book;

public class GetBooksByNameHandler : IRequestHandler<GetBooksByNameQuery, List<Models.Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksByNameHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<Models.Book>> Handle(
        GetBooksByNameQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _bookRepository.GetBooksByName(request.search);
    }
}
