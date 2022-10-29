namespace SocialMedia.Models;


public interface IPostingContextUnitOfWork {
    Repository<Comment> Comments { get; }
    Repository<Post> Posts { get; }
    Repository<ApplicationUser> Users { get; }
    Repository<Reply> Replies { get; }

    void Save();

}