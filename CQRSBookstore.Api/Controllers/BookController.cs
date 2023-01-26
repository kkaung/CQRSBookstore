using CQRSBookstore.App.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> GetBooks()
    {
        var books = await _mediator.Send(new GetBooksQuery());

        return Ok();
    }
}
