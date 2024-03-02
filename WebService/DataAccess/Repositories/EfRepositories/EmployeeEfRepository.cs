using DataAccess.DBContexts;
using DataAccess.Entities;

namespace DataAccess.Repositories.EfRepositories;

public class EmployeeEfRepository : BaseEfRepository<Employee>
{
    public EmployeeEfRepository(DatabaseContext databaseContext)
        : base(databaseContext) { }
}