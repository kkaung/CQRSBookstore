using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CQRSBookstore.Api.Controllers;

[Route("public")]
public class AccountController : ControllerBase
{
    // private readonly IMediator _mediator;

    // public AccountController(IMediator mediator)
    // {
    //     _mediator = mediator;
    // }


    [HttpPost("register")]
    public async Task<ActionResult> Register()
    {
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login()
    {
        throw new NotImplementedException();
    }
}
