using Contracts.Menus;
using CustomDinner.Application.Menus.CreateMenu;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using Mapster;

namespace CustomDinner.Api.Mappers;

public class MenuMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(
                dest => dest,
                src => src.Request)
            .Map(
                dest => dest.HostId,
                src => src.HostId);
    }
}