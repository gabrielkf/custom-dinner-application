using Contracts.Authentication;
using CustomDinner.Application.Authentication.Common;
using Mapster;

namespace CustomDinner.Api.Mappers;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id,
                src => src.User.Id.Value.ToString())
            .Map(dest => dest.Token,
                src => src.Token)
            .Map(dest => dest,
                src => src.User);
    }
}
