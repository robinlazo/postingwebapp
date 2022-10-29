using System.ComponentModel.DataAnnotations;
namespace SocialMedia.Models;

public class LogInDTO
{   
    [Required]
    public bool RememberMe { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string? ReturnURL { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}