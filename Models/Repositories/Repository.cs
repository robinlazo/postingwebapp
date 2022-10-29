using Microsoft.EntityFrameworkCore;
namespace SocialMedia.Models;

public class Repository<T> : IRepository<T> where T : class
{

    private DbSet<T> dbset { get; set; }
    protected PostingContext Context { get; set; }
    public Repository(PostingContext ctx)
    {
        Context = ctx;
        dbset = Context.Set<T>();
    }

    private int? count;

    public int Count => count ?? dbset.Count();

    public IEnumerable<T> List(QueryOptions<T> options) {
        IQueryable<T> query = BuildQuery(options);
        return query.ToList();
    }

    private IQueryable<T> BuildQuery(QueryOptions<T> options) {
        IQueryable<T> query = dbset;
        foreach(string includes in options.GetIncludes()) {
            query = query.Include(includes);
        }

        if(options.HasWhere) {
            foreach(var clause in options.WhereClauses) {
                query = query.Where(clause);
            }
        }

        if(options.HasOrderBy) {
            if(options.OrderByDirection == "asc") {
                query = query.OrderBy(options.OrderBy);
            } else {
                query = query.OrderByDescending(options.OrderBy);
            }
        }

        if(options.HasPaging) {
            query = query.Take(options.PageSize);
        }
        
        return query;
    }

    public T Get(int id) => dbset.Find(id);
    public T Get(string id) => dbset.Find(id);
    public T Get(QueryOptions<T> options) {
        IQueryable<T> query = BuildQuery(options);
        return query.FirstOrDefault();
    }

    public void Update(T entity) => dbset.Update(entity);

    public void Insert(T entity) => dbset.Add(entity);

    public void Delete(T entity) => dbset.Remove(entity);

    public void Save() => Context.SaveChanges();
}