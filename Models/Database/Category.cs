namespace SocialMedia.Models;

public class Category {
    public string CategoryID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string FontAwesomeIcon { get; set; }
    public ICollection<Post> Posts { get; set; }
}