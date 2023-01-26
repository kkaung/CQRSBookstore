using CQRSBookstore.App.Queries.Book;
using CQRSBookstore.UI.Contracts.Book;
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

    [HttpGet]
    public async Task<IActionResult> SearchBooksResult([FromQuery] SearchBooks search)
    {
        if (search.q is null)
            search.q = "";

        var books = await _mediator.Send(new GetBooksByNameQuery(search.q));

        return View(books);
    }

    [HttpGet("{bid}")]
    public async Task<IActionResult> BookDetails([FromRoute] string bid)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(new Guid(bid)));

        return View(book);
    }

    [HttpGet("reservation")]
    public async Task<IActionResult> ReservationDetails([FromQuery] SearchReservation search)
    {
        var reservation = await _mediator.Send(new GetReservationByNumberQuery(search.q));

        if (reservation is null)
            return RedirectToAction("Index", "Home");

        return View(reservation);
    }
}
