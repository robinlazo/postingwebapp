namespace SocialMedia.Models;
using System.ComponentModel.DataAnnotations;
public class ReplyDTO {
    [Required]
    public int CommentID { get; set; }

    [Required]
    [StringLength(2000, MinimumLength = 1)]
    public string Content { get; set; }
}