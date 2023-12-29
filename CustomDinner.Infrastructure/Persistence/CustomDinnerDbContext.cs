using CustomDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace CustomDinner.Infrastructure.Persistence;

public class CustomDinnerDbContext : DbContext
{
    public CustomDinnerDbContext(DbContextOptions<CustomDinnerDbContext> options) : base(options) { }

    public DbSet<Menu> Menus { get; set; } = null!;
}