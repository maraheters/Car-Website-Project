using AutoMapper;
using DatabaseAccess.Entities.CarEntities;
using DatabaseAccess.Repositories;
using Server.Models.DTOs;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;
using Server.Models.DTOs.UpdateDtos;
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

    public async Task<GetCarDto> Create(PostCarDto postCarDto)
    {
        var carEntity = _mapper.Map<CarEntity>(postCarDto);
        await _repository.Create(carEntity, postCarDto.Manufacturer, postCarDto.Category);
        return _mapper.Map<GetCarDto>(carEntity);
    }

    public async Task Update(Guid carId, PostCarDto updateCar)
    {
        var carEntity = await _repository.GetById(carId);
        if (carEntity is null)
        {
            throw new KeyNotFoundException();
        }
        
        _mapper.Map(updateCar, carEntity);

        Console.WriteLine(carEntity.Manufacturer.Name);
        // _repository.Update(carEntity, updateCar.Manufacturer.Name, updateCar.Manufacturer.Country, updateCar.Category);
    }

    public async Task Delete(Guid carId)
    {
        var carEntity = await _repository.GetById(carId);
        if (carEntity is null)
        {
            throw new KeyNotFoundException();
        }

        _repository.Delete(carEntity);
    }
}