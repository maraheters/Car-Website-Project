using AutoMapper;
using DatabaseAccess.Entities.CarEntities;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;
using Server.Models.DTOs.UpdateDtos;

namespace Server.Services.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarEntity, GetCarDto>()
            .ForMember(dest => dest.Category, opt =>
                opt.MapFrom(src => src.Category.Name));

        CreateMap<PostCarDto, CarEntity>()
            .ForMember(dest => dest.Manufacturer, opt =>
                opt.Ignore())
            .ForMember(dest => dest.Category, opt =>
                opt.MapFrom(src => new CategoryEntity { Name = src.Category }));

        CreateMap<EngineEntity, GetEngineDto>();
        CreateMap<TransmissionEntity, GetTransmissionDto>();
        CreateMap<ManufacturerEntity, GetManufacturerDto>();
        CreateMap<ImageInfoEntity, GetImageInfoDto>();
        
        CreateMap<PostEngineDto, EngineEntity>()
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            .ForMember(dst => dst.CarId, opt => opt.Ignore());
        
        CreateMap<PostTransmissionDto, TransmissionEntity>()
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            .ForMember(dst => dst.CarId, opt => opt.Ignore());
        
        CreateMap<PostImageInfoDto, ImageInfoEntity>()
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            .ForMember(dst => dst.CarId, opt => opt.Ignore());

        //For updates
        CreateMap<UpdateCarDto, CarEntity>()
            //Will deal differently for one-to-many
            .ForMember(dest => dest.Manufacturer, opt =>
                opt.Ignore())
            .ForMember(dest => dest.Category, opt =>
                opt.Ignore());



    }
}