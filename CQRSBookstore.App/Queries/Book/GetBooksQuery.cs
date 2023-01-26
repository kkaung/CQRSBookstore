using MediatR;

namespace CQRSBookstore.App.Queries.Book;

public record GetBooksQuery() : IRequest<List<Models.Book>>;
