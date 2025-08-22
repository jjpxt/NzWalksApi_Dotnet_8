using AutoMapper;
using NzWalksApi_Dotnet_8.Models.Domain;
using NzWalksApi_Dotnet_8.Models.DTO;

namespace NzWalksApi_Dotnet_8.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<AddRegionRequestDto, Region>().ReverseMap();
        CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

        CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
        CreateMap<Walk, WalkDto>().ReverseMap();

        CreateMap<Difficulty, DifficultyDto>().ReverseMap();
    }
}
