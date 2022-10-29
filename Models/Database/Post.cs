namespace SocialMedia.Models;

public class Post {
    public int PostID { get; set; }

    public string Description { get; set; }

    public DateTime Time { get; set; }

    public string Title { get; set; }

    public ICollection<Comment> Comments { get; set; }

    public ApplicationUser User { get; set; }
    public int UserID { get; set; }

    public string CategoryID { get; set; }
    public Category Category { get; set; }
}