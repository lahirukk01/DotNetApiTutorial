using System.ComponentModel.DataAnnotations;

namespace DotnetAPI.Models;

public partial class User
{
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
}