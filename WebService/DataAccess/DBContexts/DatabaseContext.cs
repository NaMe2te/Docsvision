using System.Security.Cryptography;
using System.Text;
using DataAccess.CodeForms.Enums;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBContexts;

public class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Account> Accounts { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
        Seed();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
    
    private void Seed()
    {
        if (Employees.Any())
            return;

        var account1 = new Account("root@mail.ru", HashPassword("root"));
        Accounts.Add(account1);
        
        var employee1 = new Employee("Shishkin Vladislav Aleksndrovich", Department.It);
        employee1.Account = account1;
        Employees.Add(employee1);
        
        var account2 = new Account("string@mail.ru", HashPassword("string"));
        Accounts.Add(account2);

        var employee2 = new Employee("Nikitin Nikita Nikitovich", Department.Marketing);
        Employees.Add(employee2);
        
        var account3 = new Account("prik@mail.ru", HashPassword("prik"));
        Accounts.Add(account3);
        
        var employee3 = new Employee("Ivanov Ivan Ivanovich", Department.It);
        employee3.Account = account2;
        Employees.Add(employee3);

        SaveChanges();
    }
    
    private string HashPassword(string password) // метод, чтобы загрузить данные при первом запуске программы
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}