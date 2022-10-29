namespace SocialMedia.Models;

public interface IRepository<T> where T : class {

    IEnumerable<T> List(QueryOptions<T> options);
    void Update(T entity);
    void Insert(T entity);
    void Delete(T entity);
    T Get(int id);
    void Save();
}