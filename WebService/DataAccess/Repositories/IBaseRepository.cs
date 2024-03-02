using System.Linq.Expressions;

namespace DataAccess.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> Add(TEntity model);
    Task<TEntity> Update(TEntity model);

    Task Delete(TEntity model);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAll();
}