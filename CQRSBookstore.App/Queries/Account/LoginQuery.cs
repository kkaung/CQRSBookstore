using MediatR;
using CQRSBookstore.App.Constracts.Account;

namespace CQRSBookstore.App.Queries.Account;

public record LoginQuery(string Email, string Password): IRequest<AuthResponse>;