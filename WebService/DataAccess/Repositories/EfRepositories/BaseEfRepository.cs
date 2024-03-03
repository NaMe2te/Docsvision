using System.Linq.Expressions;
using DataAccess.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.EfRepositories;

public abstract class BaseEfRepository<TXui> : IBaseRepository<TXui> where TXui : class
{
    protected readonly DatabaseContext _databaseContext;

    protected BaseEfRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<TXui> Add(TXui entity)
    {
        return (await _databaseContext.Set<TXui>().AddAsync(entity)).Entity;
    }

    public async Task<TXui> Update(TXui model)
    {
        return _databaseContext.Set<TXui>().Update(model).Entity;
    }

    public TXui Delete(TXui model)
    {
        return _databaseContext.Set<TXui>().Remove(model).Entity;
    }

    public async Task<TXui> Get(Expression<Func<TXui, bool>> predicate)
    {
        return await _databaseContext.Set<TXui>().FirstOrDefaultAsync(predicate) ?? throw new ArgumentNullException(nameof(TXui));
    }

    public async Task<IEnumerable<TXui>> GetAll(Expression<Func<TXui, bool>>? predicate = null)
    {
        IQueryable<TXui> queryable = _databaseContext.Set<TXui>();

        if (predicate is not null)
        {
            queryable = queryable.Where(predicate);
        }

        return await queryable.ToListAsync();
    }
}