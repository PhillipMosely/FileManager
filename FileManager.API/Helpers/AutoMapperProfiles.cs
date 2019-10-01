using System.Linq;
using AutoMapper;
using FileManager.API.Dtos;
using FileManager.API.Models;

namespace FileManager.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>();
            CreateMap<User,UserForDetailedDto>();
            CreateMap<UserForUpdateDto,User>();
            CreateMap<UserForRegisterDto,User>();

        }
    }
}