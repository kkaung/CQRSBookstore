using MediatR;
using Microsoft.AspNetCore.Mvc;
using CQRSBookstore.App.Queries.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;

namespace CQRSBookstore.Api.Controllers;

[EnableCors("AllowSpecificOrigin")]
[Authorize]
[Route("api/users")]
public class UserController : ControllerBase
{
    private IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        // get user id from claim
        var uid = new Guid(HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await _mediator.Send(new GetUserByIdQuery(uid));

        return Ok(result);
    }
}
