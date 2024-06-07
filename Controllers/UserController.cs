using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UserController: ControllerBase
{
    public UserController(IConfiguration config)
    {
        // Console.WriteLine(config.GetConnectionString("DefaultConnection"));
    }

    [HttpGet("", Name = "GetUsers")]
    public string GetUsers()
    {
        return "Hello Worlds";
    }
}
