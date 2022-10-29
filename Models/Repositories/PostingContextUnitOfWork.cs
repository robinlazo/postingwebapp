namespace SocialMedia.Models;

public class PostingContextUnitOfWork : IPostingContextUnitOfWork {

    private PostingContext Context { get; }
    public PostingContextUnitOfWork(PostingContext ctx) => Context = ctx;

    private Repository<Comment> CommentsData;
    public Repository<Comment> Comments {
        get {
            if(CommentsData == null) {
                CommentsData = new Repository<Comment>(Context);
            }

            return CommentsData;
        }
    }
    private Repository<ApplicationUser> UsersData;
    public Repository<ApplicationUser> Users {
        get {
            if(UsersData == null) {
                UsersData = new Repository<ApplicationUser>(Context);
            }

            return UsersData;
        }
    }
    private Repository<Post> PostsData;
    public Repository<Post> Posts {
        get {
            if(PostsData == null) {
                PostsData = new Repository<Post>(Context);
            }

            return PostsData;
        }
    }
    private Repository<Reply> RepliesData;
    public Repository<Reply> Replies {
        get {
            if(RepliesData == null) {
                RepliesData = new Repository<Reply>(Context);
            }

            return RepliesData;
        }
    }

    private Repository<Category> categoryData;
    public Repository<Category> Categories {
        get {
            if(categoryData == null) {
                categoryData = new Repository<Category>(Context);
            }

            return categoryData;
        }
    }

    public void Save() => Context.SaveChanges();

}