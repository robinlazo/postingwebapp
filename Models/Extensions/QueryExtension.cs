namespace SocialMedia.Models;

public static class QueryExtensions
{
    public static IQueryable<T> PageBy<T>(this IQueryable<T> options, int PageSize)
    {
        return options.Take(PageSize);
    }
}