using Manager.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Api.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(c => c.Surname)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(256);
        
        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.Property(c => c.CreatedAtUtc)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}