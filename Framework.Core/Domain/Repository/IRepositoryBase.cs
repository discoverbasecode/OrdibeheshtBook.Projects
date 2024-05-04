using System.Linq.Expressions;

namespace Framework.Core.Domain.Repository;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task AddRange(ICollection<T> entities);
    Task AddAsync(T entity);
    Task<T?> GetAsync(long id);
    Task<T?> GetTracking(long id);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    Task<int> Save();


    void Add(T entity);
    T? Get(long id);
    bool Exists(Expression<Func<T, bool>> expression);
    void Update(T entity);



}