using Microsoft.EntityFrameworkCore;
using PowerUp.Infrastructure.Configurations;

namespace PowerUp.Infrastructure;

public class PowerUpContext : DbContext
{
    public PowerUpContext(DbContextOptions<PowerUpContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}