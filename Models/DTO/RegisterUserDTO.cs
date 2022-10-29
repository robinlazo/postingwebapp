using System.ComponentModel.DataAnnotations;
namespace SocialMedia.Models;


public class RegisterUserDTO
{
    [Required]
    [StringLength(50, MinimumLength = 4)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Compare("ConfirmPassword", ErrorMessage = "Password and Confirm Password must be the same")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}