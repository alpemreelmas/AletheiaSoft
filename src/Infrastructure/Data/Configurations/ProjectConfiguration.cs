using AletheiaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AletheiaSoft.Infrastructure.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(t => t.Description)
            .IsRequired();
        
        builder.Property(t => t.Budget)
            .IsRequired();

        builder.Property(t => t.StartDate)
            .IsRequired();
        
        builder.Property(t => t.LastDate)
            .IsRequired();
        
        builder.Property(t => t.Currency)
            .IsRequired();
    }
}
