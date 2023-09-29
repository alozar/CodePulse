using AutoMapper;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;

namespace CodePulse.API.Infrastructure;

public class AppMappingProfile: Profile
{
    public AppMappingProfile()
    {
        CreateMap<CreateCategoryRequestDto, Category>();
        CreateMap<CategoryDto, Category>().ReverseMap();
    }
}
