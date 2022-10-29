using Microsoft.AspNetCore.Identity;
namespace SocialMedia.Models;


public class ApplicationUser : IdentityUser<int>{


    public DateTime CreationTime { get; set; }

    public ICollection<Post> Posts { get; set; }

    public ICollection<Comment> Comments { get; set; }

    public ICollection<Reply> Replies { get; set; }

}