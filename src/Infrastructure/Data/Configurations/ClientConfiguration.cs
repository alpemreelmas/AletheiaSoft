using AletheiaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AletheiaSoft.Infrastructure.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(t => t.FullName)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(t => t.Email)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(t => t.Phone)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Adress)
            .HasMaxLength(200);
        
        builder.Property(t => t.ProfilePic)
            .HasMaxLength(200);

    }
}
