namespace SocialMedia.Models;

public class PostViewModel {
    public Post Post { get; set; }

    public CommentDTO CommentDTO { get; set; }

    public ReplyDTO Reply { get; set; } = new ReplyDTO();
}