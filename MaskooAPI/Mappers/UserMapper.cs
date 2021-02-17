using AutoMapper;
using DAL.Entities.User;
using MaskooAPI.Models.Users;
using Services.Users.Models;

namespace MaskooAPI.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<LoginRequest, LoginParameter>();

            CreateMap<User, UserResponse>();

            CreateMap<SignUpRequest, SignUpParameter>();
        }
    }
}
