using AutoMapper;
using PlatfromService.Models;
using PlatfromService.DTOs;

namespace PlatfromService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile() 
        {
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, Platform>();
        }
    }
}
