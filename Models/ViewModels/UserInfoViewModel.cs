namespace SocialMedia.Models;


public class UserInfoViewModel {
    public ApplicationUser User { get; set; }
    public IEnumerable<Post> UserPosts { get; set; }
}