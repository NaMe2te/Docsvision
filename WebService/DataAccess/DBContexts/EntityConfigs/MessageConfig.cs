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
            .WithMany(e => e.ReceivedMessages)
            .HasForeignKey(m => m.AddresseeId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(e => e.Id);

        builder
            .HasOne(m => m.Sender)
            .WithMany(e => e.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(e => e.Id);
    }
}