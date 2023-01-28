using MediatR;
using CQRSBookstore.App.Commands.Book;
using CQRSBookstore.App.Queries.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CQRSBookstore.Api.Commom.Book;

namespace CQRSBookstore.Api.Controllers;

[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly ISender _mediator;

    public BookController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] string q)
    {
        // if q has value, return the results of the search
        if (q is not null)
            return Ok(await _mediator.Send(new GetBooksByNameQuery(q)));

        var result = await _mediator.Send(new GetBooksQuery());

        return Ok(result);
    }

    [HttpGet("{bid}")]
    public async Task<IActionResult> BookDetails([FromRoute] string bid)
    {
        var result = await _mediator.Send(new GetBookByIdQuery(new Guid(bid)));

        return Ok(result);
    }

    [HttpGet("{bid}/reservation")]
    public async Task<IActionResult> BookReservationDetails([FromRoute] int bid)
    {
        var result = await _mediator.Send(new GetReservationByNumberQuery(bid));
        return Ok(result);
    }

    [HttpPost("reservation")]
    public async Task<IActionResult> BookReservation([FromBody] BookReservationRequest request)
    {
        // get user id from claim
        var uid = new Guid(HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await _mediator.Send(new CreateReservationCommand(uid, request.Bid));

        return Ok(result);
    }

    [HttpGet("reservation/{rid}")]
    public async Task<IActionResult> GetReservation([FromRoute] int rid)
    {
        var result = await _mediator.Send(new GetReservationByNumberQuery(rid));

        return Ok(result);
    }
}
