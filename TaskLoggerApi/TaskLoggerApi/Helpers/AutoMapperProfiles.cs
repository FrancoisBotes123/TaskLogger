using AutoMapper;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserReturnDTO>();
            CreateMap<AppUser, UserLoginDTO>();
            CreateMap<UserLoginDTO, AppUser>();
            CreateMap<AppUser, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, AppUser>();

        }
    }
}
