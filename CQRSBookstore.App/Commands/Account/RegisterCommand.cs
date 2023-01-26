using MediatR;
using CQRSBookstore.App.Constracts.Account;

namespace CQRSBookstore.App.Commands.Account;

public record RegisterCommand(string Username, string Email, string Password) : IRequest<AuthResult>;


