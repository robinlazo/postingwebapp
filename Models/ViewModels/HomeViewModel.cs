namespace SocialMedia.Models;

public class HomeViewModel {
    public IEnumerable<Post> Posts { get; set; }

    public SortDictionary Routes { get; set; }

    public IEnumerable<Category> Categories { get; set; }
}