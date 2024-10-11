using AutoMapper;
using DatabaseAccess.Entities.CarEntities;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;

namespace Server.Services.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarEntity, GetCarDto>()
            .ForMember(dest => dest.Manufacturer, opt =>
                opt.MapFrom(src => src.Manufacturer.Name))
            .ForMember(dest => dest.Category, opt =>
                opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Images, opt =>
                opt.MapFrom(src => src.Images.Urls.ToList()));

        CreateMap<PostCarDto, CarEntity>()
            .ForMember(dest => dest.Manufacturer, opt =>
                opt.Ignore())            
            .ForMember(dest => dest.Category, opt =>
                opt.MapFrom(src => new CategoryEntity { Name = src.Category }))            
            .ForMember(dest => dest.Images, opt =>
                opt.MapFrom(src => new ImageInfoEntity { Urls = src.Images }));

        CreateMap<PostEngineDto, EngineEntity>();
        CreateMap<EngineEntity, GetEngineDto>();

    }
}