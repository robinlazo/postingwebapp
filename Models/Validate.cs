namespace SocialMedia.Models;

public class Validate {

    public bool IsValid { get; private set; }
    public string ErrorMessage { get; private set; }
    public void CheckCategory(Repository<Category> data, string categoryId) {
        var categoryItem = data.Get(categoryId);
        IsValid = (categoryItem == null) ? false : true;
        ErrorMessage = (IsValid) ? "" : $"{categoryId} is not a valid category";
    }

    public void CheckPost(Repository<Post> data, int postId) {
        var postItem = data.Get(postId);
        IsValid = (postItem == null) ? false : true;
        ErrorMessage = (IsValid) ? "" : $"{postId} doesn't exists";
    }
}