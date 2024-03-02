using System.Linq.Expressions;
using DataAccess.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.EfRepositories;

public abstract class BaseEfRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DatabaseContext _databaseContext;

    protected BaseEfRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        return (await _databaseContext.Set<TEntity>().AddAsync(entity)).Entity;
    }

    public async Task<TEntity> Update(TEntity model)
    {
        return _databaseContext.Set<TEntity>().Update(model).Entity;
    }

    public async Task Delete(TEntity model)
    {
        _databaseContext.Set<TEntity>().Remove(model);
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await _databaseContext.Set<TEntity>().FirstOrDefaultAsync(predicate) ?? throw new ArgumentNullException(nameof(TEntity));
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _databaseContext.Set<TEntity>().ToListAsync();
    }
}