using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void CommitTransaction();
    Task<int> SaveChangesAsync();
    int SaveChanges();
}