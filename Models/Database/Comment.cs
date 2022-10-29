namespace SocialMedia.Models;

public class Comment {

    public int CommentID { get; set; }

    public DateTime Time { get; set; }

    public string Content { get; set; }

    public ICollection<Reply> Replies { get; set; }

    public int PostID { get; set; }
    public Post Post { get; set; }

    public int UserID { get; set; }
    public ApplicationUser User { get; set; }

}