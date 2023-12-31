using CustomDinner.Domain.DinnerAggregate;
using CustomDinner.Domain.DinnerAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate;
using CustomDinner.Domain.MenuAggregate.Entities;
using CustomDinner.Domain.MenuAggregate.ValueObjects;
using CustomDinner.Domain.MenuReviewAggregate;
using CustomDinner.Domain.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    private const string MenusTableName = "Menus";
    private const string MenuSectionsTableName = "MenuSections";
    private const string MenuSectionItemsTableName = "MenuSectionItems";
    private const string MenuDinnerIdTableName = "MenuDinnerIds";
    private const string MenuReviewIdTableName = "MenuReviewIds";
    
    private const int NameMaxLength = 100;
    private const int DescriptionMaxLength = 500;

    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIds(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable(MenusTableName);

        builder.HasKey(menu => menu.Id);
        
        builder
            .Property(menu => menu.Id)
            .ValueGeneratedNever()
            .HasConversion(menuId => menuId.Value,
                id => MenuId.Create(id));

        builder
            .Property(menu => menu.Name)
            .HasMaxLength(NameMaxLength);
        builder
            .Property(menu => menu.Description)
            .HasMaxLength(DescriptionMaxLength);

        builder
            .Property(menu => menu.HostId)
            .HasConversion(hostId => hostId.Value,
                id => HostId.Create(id));

        builder.OwnsOne(menu => menu.AverageRating);
    }

    private static void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            menu => menu.Sections,
            sectionBuilder =>
            {
                sectionBuilder.ToTable(MenuSectionsTableName);
                
                sectionBuilder.WithOwner().HasForeignKey(nameof(MenuId));
                sectionBuilder.HasKey(nameof(MenuSection.Id), nameof(MenuId));
                
                sectionBuilder
                    .Property(section => section.Id)
                    .ValueGeneratedNever()
                    .HasConversion(sectionId => sectionId.Value,
                        id => MenuSectionId.Create(id));

                sectionBuilder
                    .Property(section => section.Name)
                    .HasMaxLength(NameMaxLength);
                sectionBuilder
                    .Property(section => section.Description)
                    .HasMaxLength(DescriptionMaxLength);

                sectionBuilder
                    .OwnsMany(section => section.Items,
                        itemsBuilder =>
                        {
                            itemsBuilder.ToTable(MenuSectionItemsTableName);

                            itemsBuilder.WithOwner().HasForeignKey(nameof(MenuSectionId), nameof(MenuId));
                            itemsBuilder.HasKey(
                                nameof(MenuItem.Id),
                                nameof(MenuSectionId),
                                nameof(MenuId));

                            itemsBuilder
                                .Property(item => item.Id)
                                .HasColumnName(nameof(MenuItemId))
                                .ValueGeneratedNever()
                                .HasConversion(itemId => itemId.Value,
                                    id => MenuItemId.Create(id));

                            itemsBuilder
                                .Property(item => item.Name)
                                .HasMaxLength(NameMaxLength);
                            itemsBuilder
                                .Property(item => item.Description)
                                .HasMaxLength(DescriptionMaxLength);
                        });
                
                sectionBuilder.Navigation(section => section.Items).Metadata.SetField("_items");
                sectionBuilder.Navigation(section => section.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        
        builder.Metadata
            .FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIds(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.DinnerIds,
            dinnerIdsBuilder =>
            {
                dinnerIdsBuilder.ToTable(MenuDinnerIdTableName);

                dinnerIdsBuilder.WithOwner().HasForeignKey(nameof(MenuId));
                dinnerIdsBuilder.HasKey(nameof(Dinner.Id));

                dinnerIdsBuilder
                    .Property(dinnerId => dinnerId.Value)
                    .HasColumnName(nameof(DinnerId))
                    .ValueGeneratedNever();
            });

        builder.Metadata
            .FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.ReviewIds,
            reviewIdsBuilder =>
            {
                reviewIdsBuilder.ToTable(MenuReviewIdTableName);

                reviewIdsBuilder.WithOwner().HasForeignKey(nameof(MenuId));
                reviewIdsBuilder.HasKey(nameof(MenuReview.Id));

                reviewIdsBuilder
                    .Property(reviewId => reviewId.Value)
                    .HasColumnName(nameof(MenuReviewId))
                    .ValueGeneratedNever();
            });

        builder.Metadata
            .FindNavigation(nameof(Menu.ReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}