using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.DBContexts;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=LAPTOP-9H8CH352\\SQLEXPRESS;Database=docsvision;Trusted_Connection=True;TrustServerCertificate=True");
        return new DatabaseContext(optionsBuilder.Options);
    }
}