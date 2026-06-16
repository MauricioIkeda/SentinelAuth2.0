using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelAuth.Domain.Entities;
using SentinelAuth.Domain.ValueObjects;

namespace SentinelAuth.Infrastructure.Data.Configurations;

public class UserConfigurationMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(user => user.Id);
        
        builder.Property(user => user.Id).HasColumnName("id");
        builder.Property(user => user.Name).HasColumnName("name").IsRequired().HasMaxLength(128);
        
        builder.Property(user => user.Email).HasConversion(
            email => email.Value,
            value => Email.Create(value).Data!
        ).HasColumnName("email").IsRequired().HasMaxLength(250);
        
        builder.Property(user => user.PasswordHash).HasColumnName("passwordHash").IsRequired().HasMaxLength(250);
    }
}