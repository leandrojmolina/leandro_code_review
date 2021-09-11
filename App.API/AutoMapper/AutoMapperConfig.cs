using App.Domain.Entities;
using AutoMapper;

namespace App.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, App.API.Models.User>().ReverseMap();
            CreateMap<UserRole, App.API.Models.UserRole>().ReverseMap();
            CreateMap<Role, App.API.Models.Role>().ReverseMap();
            CreateMap<Office, App.API.Models.Office>().ReverseMap();
        }
    }
}
