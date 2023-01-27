using CQRSBookstore.App.Commands.Account;
using CQRSBookstore.UI.Contracts.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CQRSBookstore.App.Queries.Account;
using Microsoft.AspNetCore.Identity;
using CQRSBookstore.App.Models;

namespace CQRSBookstore.UI.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly ISender _mediator;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(ILogger<AccountController> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("register")]
    public async Task<IActionResult> PostRegister(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Username, request.Email, request.Password);
        var result = await _mediator.Send(command);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> PostLogin(LoginRequest request)
    {
        var command = new LoginQuery(request.Email, request.Password);
        var result = await _mediator.Send(command);

        if (result is not null) { }

        return RedirectToAction("Index", "Home");
    }
}
