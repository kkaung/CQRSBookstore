
using MediatR;

namespace CQRSBookstore.App.Queries.User;

public record GetUserByIdQuery(Guid uid) : IRequest<Models.User>;

