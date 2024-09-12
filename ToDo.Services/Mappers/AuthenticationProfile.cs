using AutoMapper;
using ToDo.Core.Entities;
using ToDo.Core.Models.Requests;

namespace ToDo.Services.Mappers;

public class AuthenticationProfile: Profile
{
    public AuthenticationProfile()
    {
        CreateMap<AuthenticationRequest, Authentication>()
            .ForMember(x => x.AuthenticationToken, src => src.Ignore())
            .ReverseMap();
    }
}