using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.DBContexts.EntityConfigs;

public class MessageConfig : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder
            .HasOne(m => m.Addressee)
            .WithMany(e => e.Messages)
            .HasForeignKey(m => m.AddresseeId);

        builder
            .HasOne(m => m.Sender)
            .WithMany(e => e.Messages)
            .HasForeignKey(m => m.SenderId);
    }
}