// Controllers/TestController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult Public() => Ok("This is a public endpoint.");

    [Authorize]
    [HttpGet("protected")]
    public IActionResult Protected() => Ok("This is a protected endpoint.");
}
