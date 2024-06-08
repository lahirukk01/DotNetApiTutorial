using System.ComponentModel.DataAnnotations;
using DotnetAPI.Models;

namespace DotnetAPI.Dtos;

public class UserCreateDto
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Email { get; set; }
    
    [Required]
    [EnumDataType(typeof(User.Genders))]
    public string Gender { get; set; }
    
    [Required]
    public bool Active { get; set; }

    public new string ToString()
    {
        return $"FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, Gender: {Gender}, Active: {Active}";
    }
}
