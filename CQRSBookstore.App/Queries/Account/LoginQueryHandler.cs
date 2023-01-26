using MediatR;
using CQRSBookstore.App.Constracts.Account;
using CQRSBookstore.App.Common.interfaces.Repositories;
using CQRSBookstore.App.Common.interfaces.Account;

namespace CQRSBookstore.App.Queries.Account;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResponse>
{
    private IUserRepository _userRepository;
    private IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);

        // validate the user exists
        if (user is null) { }

        // valite the password is correct
        if (user!.Password != request.Password) { }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return null;

        // return new AuthResponse(){Id = user.Id, Username = user.Username, Email = user.Email, Token = token};
    }
}
