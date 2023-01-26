using MediatR;
using CQRSBookstore.App.Common.interfaces.Repositories;

namespace CQRSBookstore.App.Queries.Book;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Models.Book>
{
    private IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Models.Book?> Handle(
        GetBookByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _bookRepository.GetBookById(request.Id);
    }
}
