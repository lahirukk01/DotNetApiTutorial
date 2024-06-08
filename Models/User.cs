using System.ComponentModel.DataAnnotations;
using DotnetAPI.Dtos;

namespace DotnetAPI.Models;

public partial class User
{
    public enum Genders
    {
        Male, Female, Other
    }
    
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = "";
    
    [StringLength(50)]
    public string LastName { get; set; } = "";
    
    [StringLength(50)]
    public string Email { get; set; } = "";
    
    [StringLength(10)]
    public string Gender { get; set; } = "";
    
    public bool Active { get; set; }
    
    public User() { }

    public User(UserCreateDto userCreateDto)
    {
        FirstName = userCreateDto.FirstName;
        LastName = userCreateDto.LastName;
        Email = userCreateDto.Email;
        Gender = userCreateDto.Gender;
        Active = userCreateDto.Active;
    }
}