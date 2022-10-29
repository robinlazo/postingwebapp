namespace SocialMedia.Models;

public class PostQueryOptions : QueryOptions<Post> {
    public void SortFilter(IndexSession session) {
        if(session.HasCategory) {
            Where = p => p.CategoryID == session.CurrentRoute.CategoryFilter;
        }
    }
}