using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using net_jwt.Models;

namespace net_jwt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SignInController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public async Task<ActionResult> SignIn([FromBody] User request)
    {
        Console.WriteLine(request.Username);
        string username1 = "rohan";
        string password1 = "pass";
        if (request.Username != username1 || request.Password != password1)
        {
            return Unauthorized(new {message = "Invalid credentials"});
        }
        Console.WriteLine("Triggered");
        return Ok(new {message = "nice"});
    }
}