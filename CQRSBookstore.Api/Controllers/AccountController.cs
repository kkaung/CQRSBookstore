using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSBookstore.Api.Controllers;

[Route("api/public")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // [HttpPost("register")]
    // public async Task<ActionResult> Register() { }

    // [HttpPost("login")]
    // public async Task<ActionResult> Login() {

    // }
}
