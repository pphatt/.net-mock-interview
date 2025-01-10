using AutoMapper;
using Server.Application.Common.Dtos.Users;
using Server.Application.Features.UsersApp.Commands.CreateUser;
using Server.Application.Features.UsersApp.Commands.UpdateUser;
using Server.Domain.Entity.Identity;

namespace Server.API.Common.Mapper;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<AppUser, UserDto>();

        CreateMap<CreateUserCommand, AppUser>()
            .ForMember(u => u.Id, opt => opt.Ignore())
            .ForMember(u => u.Dob, opt => opt.MapFrom(src => DateTime.Parse(src.Dob.ToString())))
            .ForMember(u => u.DateCreated, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(u => u.DateUpdated, opt => opt.Ignore())
            .ForMember(u => u.DateDeleted, opt => opt.Ignore());
    }
}
