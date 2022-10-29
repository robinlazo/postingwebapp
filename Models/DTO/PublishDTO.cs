namespace SocialMedia.Models;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
public class PublishDTO {
    [Required]
    [StringLength(60, MinimumLength = 20)]
    public string Title { get; set; }

    [Required]
    [StringLength(5000, MinimumLength = 120)]
    public string Description { get; set; }

    [Required]
    public string CategoryID { get; set; }

  
    public IEnumerable<Category>? Categories { get; set; }
}