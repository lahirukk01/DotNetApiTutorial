using DotnetAPI.Data;
using DotnetAPI.Dtos;
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
    
    [HttpPost("", Name = "CreateUser")]
    public IActionResult CreateUser([FromBody] UserCreateDto userCreateDto)
    {
        Console.WriteLine(userCreateDto.ToString());
        var user = new User(userCreateDto);
        _ef.Users.Add(user);
        _ef.SaveChanges();
        
        return CreatedAtRoute("GetUser", new { id = user.Id }, new { user = user });
    }
    
    [HttpDelete("{id}", Name = "DeleteUser")]
    public IActionResult DeleteUser(int id)
    {
        User? user = _ef.Users.Find(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        _ef.Users.Remove(user);
        _ef.SaveChanges();
        
        return Ok();
    }
}
