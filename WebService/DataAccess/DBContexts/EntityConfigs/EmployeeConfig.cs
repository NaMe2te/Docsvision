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
            .HasMany(e => e.SentMessages)
            .WithOne(m => m.Sender)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(e => e.Id);

        builder
            .HasMany(e => e.ReceivedMessages)
            .WithOne(m => m.Addressee)
            .HasForeignKey(m => m.AddresseeId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(e => e.Id);

        builder.HasOne(e => e.Account);
    }
}