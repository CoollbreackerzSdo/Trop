using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trop.Domain.Models.User;

namespace Trop.Infrastructure.Context;

public class UserConfiguration : ConfigurationBase<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder
            .HasIndex(x => x.UserName)
            .IsUnique();

        builder
            .Property(x => x.UserName)
            .IsRequired()
            .HasColumnName("user_name").HasMaxLength(100);

        builder
            .ComplexProperty(x => x.Security, options =>
            {
                options
                    .Property(x => x.Email)
                    .HasColumnName("email")
                    .IsRequired();
                options
                    .Property(x => x.Password)
                    .HasColumnName("password")
                    .IsRequired();
            });

        builder
            .OwnsOne(x => x.Detail, x => x.ToJson("detail"));

        builder
            .Property(x => x.RegisterDateAtUtc)
            .IsRequired()
            .HasColumnName("register_date_utc");

        builder
            .Property(x => x.RegisterTimeAtUtc)
            .IsRequired()
            .HasColumnName("register_time_utc");
    }
}