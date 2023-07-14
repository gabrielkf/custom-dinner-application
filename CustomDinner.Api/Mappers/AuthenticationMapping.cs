using System.Reflection;
using Contracts.Authentication;
using CustomDinner.Application.Authentication.Commands.Common;
using Mapster;
using MapsterMapper;

namespace CustomDinner.Api.Mappers;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
