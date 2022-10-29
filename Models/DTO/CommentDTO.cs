namespace SocialMedia.Models;
using System.ComponentModel.DataAnnotations;
public class CommentDTO {
    [Required]
    public int PostID { get; set; }

    [Required]
    [StringLength(6000, MinimumLength = 1)]
    public string Content { get; set;}
}