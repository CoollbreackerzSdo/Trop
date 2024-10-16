using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trop.Domain.Common;

namespace Trop.Infrastructure.Context;

public class ConfigurationBase<T> : IEntityTypeConfiguration<T>
    where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .HasKey(x => x.Key);

        builder
            .Property(x => x.Key)
            .HasColumnName("key")
            .HasConversion(x => x.Value, x => new(x))
            .IsRequired();
    }
}
