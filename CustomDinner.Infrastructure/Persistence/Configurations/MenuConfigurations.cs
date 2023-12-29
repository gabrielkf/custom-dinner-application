using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate;
using CustomDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    private const string TableName = "Menus";
    
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(menu => menu.Id);
        
        builder
            .Property(menu => menu.Id)
            .ValueGeneratedNever()
            .HasConversion(
                menuId => menuId.Value,
                id => MenuId.Create(id));

        builder
            .Property(menu => menu.Name)
            .HasMaxLength(100);
        
        builder
            .Property(menu => menu.Description)
            .HasMaxLength(300);

        builder
            .Property(menu => menu.HostId)
            .HasConversion(
                hostId => hostId.Value,
                id => HostId.Create(id));

        builder.OwnsOne(menu => menu.AverageRating);
    }
}