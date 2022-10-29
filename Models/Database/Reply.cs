namespace SocialMedia.Models;

using System.ComponentModel.DataAnnotations;
public class Reply {
    
    public int ReplyID { get; set; }

    public DateTime Time { get; set; }

    public string Content { get; set; }
   
    public int CommentID { get; set; }
    public Comment Comment { get; set; }

    public int UserID { get; set; }
    public ApplicationUser User { get; set; }
}