using Microsoft.EntityFrameworkCore;

using Trop.Domain.Models.User;

namespace Trop.Infrastructure.Context;

public class TropContext(DbContextOptions<TropContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
    public DbSet<UserEntity> Users { get; init; } = null!;
}