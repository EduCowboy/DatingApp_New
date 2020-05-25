using AutoMapper;
using DatingApp.API.Models;
using DatingApp.API.Dtos;

namespace DatingApp.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserForRegisterDto>();
        }
        
    }
}