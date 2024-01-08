using Contracts.Menus;
using CustomDinner.Application.Menus.CreateMenu;
using CustomDinner.Domain.MenuAggregate;
using CustomDinner.Domain.MenuAggregate.Entities;
using Mapster;

namespace CustomDinner.Api.Mappers;

public class MenuMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
        //     .Map(dest => dest,
        //         src => src.Request)
        //     .Map(dest => dest.HostId,
        //         src => src.HostId);

        // todo: add AverageRating
        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id,
                src => src.Id.Value)
            .Map(dest => dest.HostId,
                src => src.HostId.Value)
            .Map(dest => dest.DinnerIds,
                src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
            .Map(dest => dest.MenuReviewIds,
                src => src.ReviewIds.Select(menuReviewId => menuReviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id,
                src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id,
                src => src.Id.Value);
    }
}