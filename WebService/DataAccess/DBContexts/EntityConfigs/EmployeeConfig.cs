using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.DBContexts.EntityConfigs;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(e => e.Messages)
            .WithOne(m => m.Sender)
            .HasForeignKey(m => m.Sender.Id);
        
        builder
            .HasMany(e => e.Messages)
            .WithOne(m => m.Addressee)
            .HasForeignKey(m => m.Addressee.Id);
    }
}