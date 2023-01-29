using CQRSBookstore.App.Common.Interface.Repositories;
using MediatR;

namespace CQRSBookstore.App.Queries.User;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Models.User>
{
    private IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Models.User?> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _userRepository.GetUserById(request.uid);
    }
}
