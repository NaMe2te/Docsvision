using DataAccess.DBContexts;
using DataAccess.Entities;

namespace DataAccess.Repositories.EfRepositories;

public class AccountEfRepository : BaseEfRepository<Account>
{
    public AccountEfRepository(DatabaseContext databaseContext)
        : base(databaseContext) { }
}