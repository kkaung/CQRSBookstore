using MediatR;

namespace CQRSBookstore.App.Queries.Book;

public record GetBookByIdQuery(Guid Id): IRequest<Models.Book>;