using Microsoft.AspNetCore.Mvc;

namespace CQRSBookstore.Api.Controllers;


[Route("api/public")]
public class AccountController : ControllerBase
{
    public AccountController() { }

    [HttpPost("register")]
    public async Task<ActionResult> Register() {

        
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login() {

    }
}
