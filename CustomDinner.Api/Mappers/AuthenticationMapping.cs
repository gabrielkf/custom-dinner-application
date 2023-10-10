using System.Reflection;
using Contracts.Authentication;
using CustomDinner.Application.Authentication.Common;
using Mapster;
using MapsterMapper;

namespace CustomDinner.Api.Mappers;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id,
                src => src.User.Id.Value.ToString())
            .Map(dest => dest.FirstName,
                src => src.User.FirstName)
            .Map(dest => dest.LastName,
                src => src.User.LastName)
            .Map(dest => dest.Email,
                src => src.User.Email)
            .Map(dest => dest.Token,
                src => src.Token);
    }
}
