using DotnetAPI.Data;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController: ControllerBase
{
    private readonly DataContextEF _ef;
    public UserController(IConfiguration config)
    {
        _ef = new DataContextEF(config);
    }

    [HttpGet("", Name = "GetUsers")]
    public IActionResult GetUsers()
    {
        IEnumerable<User> users = _ef.Users.ToList<User>();
        return Ok(new { users = users });
    }
    
    [HttpGet("{id}", Name = "GetUser")]
    public IActionResult GetUser(int id)
    {
        User? user = _ef.Users.Find(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(new { user = user });
    }
}
