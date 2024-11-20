using AutoMapper;
using PasswordHashing.DTO;
using PasswordHashing.Models;

namespace PasswordHashing.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.PasswordHash, val => val.MapFrom(src => BCrypt.Net.BCrypt.EnhancedHashPassword(src.Password, 13)));
            CreateMap<User, UserDto>();

        }
    }
}
