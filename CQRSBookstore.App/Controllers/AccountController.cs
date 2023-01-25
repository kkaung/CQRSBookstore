using Microsoft.AspNetCore.Mvc;

namespace CQRSBookstore.App.Controllers;

public class AccountController : Controller
{
    public AccountController() { }

    [HttpGet("login")]
    public IActionResult Login() 
    {
        return View();
    }
    

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }
}
