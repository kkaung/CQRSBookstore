using Microsoft.AspNetCore.Mvc;
using MediatR;
using CQRSBookstore.Api.Contracts.Account;
using CQRSBookstore.App.Commands.Account;
using CQRSBookstore.App.Queries.Account;

namespace CQRSBookstore.Api.Controllers;

[Route("public")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(request.Username, request.Email, request.Password);
        var result = await _mediator.Send(command);

        Console.WriteLine(result.Token);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
    {
        var command = new LoginQuery(request.Email, request.Password);
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
