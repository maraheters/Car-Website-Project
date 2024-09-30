using AutoMapper;
using DatabaseAccess.Entities.CarEntities;
using DatabaseAccess.Repositories;
using Server.Models.DTOs;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;
using Server.Services.Interfaces;

namespace Server.Services;

public class CarsService : ICarsService
{
    private readonly CarsRepository _repository;
    private readonly IMapper _mapper;

    public CarsService(CarsRepository repository , IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetCarDto>> GetAll()
    {
        var carsEntities = await _repository.GetAll();
        // var carsEntities = new List<CarEntity>
        // {
        //     new CarEntity
        //     {
        //         Id = Guid.NewGuid(),
        //         Model = "Hilux",
        //         Category = new CategoryEntity { Id = Guid.NewGuid(), Name = "Pickup", Cars = null },
        //         Manufacturer = new ManufacturerEntity { Id = new Guid(), Name = "Toyota", Cars = null },
        //         Images = new ImageInfoEntity{ Id = Guid.NewGuid(), Urls = {"A", "B", "C"}, Car = null },
        //         Mileage = 28,
        //         CategoryId = new Guid(),
        //         Price = 22000,
        //         Year = 2020,
        //         ManufacturerId = new Guid()
        //     },
        //     new CarEntity
        //     {
        //         Id = Guid.NewGuid(),
        //         Model = "Optima",
        //         Category = new CategoryEntity { Id = Guid.NewGuid(), Name = "Pickup", Cars = null },
        //         Manufacturer = new ManufacturerEntity { Id = new Guid(), Name = "Kia", Cars = null },
        //         Images = null,
        //         Mileage = 69,
        //         CategoryId = new Guid(),
        //         Price = 14000,
        //         Year = 2014,
        //         ManufacturerId = new Guid()
        //     }
        // };
        
        var carDtos = carsEntities
            .Select(carEntity => _mapper.Map<GetCarDto>(carEntity))
            .ToList();
        
        return carDtos;
    }

    public async Task<GetCarDto> GetById(Guid carId)
    {
        var carEntity = await _repository.GetById(carId);
        return _mapper.Map<GetCarDto>(carEntity);
    }

    public async Task<GetCarDto> CreateCar(PostCarDto postCarDto)
    {
        var carEntity = _mapper.Map<CarEntity>(postCarDto);
        await _repository.Create(carEntity, postCarDto.Manufacturer, postCarDto.Category);
        return _mapper.Map<GetCarDto>(carEntity);
    }

    public Task<GetCarDto> UpdateCar(Guid carId, GetCarDto getCar)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCar(Guid carId)
    {
        throw new NotImplementedException();
    }
}