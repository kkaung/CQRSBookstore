using CQRSBookstore.App.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSBookstore.UI.Controllers;

[Route("books")]
public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly ISender _mediator;

    public BookController(ILogger<BookController> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{bid}")]
    public async Task<IActionResult> BookDetails([FromRoute] string bid)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(new Guid(bid)));

        return View(book);
    }
}
