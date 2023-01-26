using MediatR;

namespace CQRSBookstore.App.Queries.Book;

public record GetBooksByNameQuery(string search): IRequest<List<Models.Book>>;

