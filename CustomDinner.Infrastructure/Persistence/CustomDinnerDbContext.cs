using CustomDinner.Domain.MenuAggregate;
using CustomDinner.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace CustomDinner.Infrastructure.Persistence;

public class CustomDinnerDbContext : DbContext
{
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    public CustomDinnerDbContext(DbContextOptions<CustomDinnerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CustomDinnerDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}