using MediatR;
using CQRSBookstore.App.Constracts.Account;
using CQRSBookstore.App.Common.Interface.Repositories;
using CQRSBookstore.App.Models;
using CQRSBookstore.App.Common.Interface.Account;

namespace CQRSBookstore.App.Commands.Account;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult>
{
    private IUserRepository _userRepository;
    private IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {

        // validate the user exists
        if(await _userRepository.GetUserByEmail(request.Email) is not null) {
            Console.WriteLine("User Exists");
        }

        var user = new User() {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password
        };

        await _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }
}
