using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWork;
public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;

    private IDbContextTransaction _transaction;

    public UnitOfWork(TContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _transaction.Commit();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }
}