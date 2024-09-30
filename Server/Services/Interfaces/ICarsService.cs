using Server.Models.DTOs;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;

namespace Server.Services.Interfaces;

public interface ICarsService
{
    public Task<List<GetCarDto>> GetAll();
    public Task<GetCarDto> GetById(Guid carId);
    
    public Task<GetCarDto> CreateCar(PostCarDto postCarDto);
    public Task<GetCarDto> UpdateCar(Guid carId, GetCarDto getCar);
    public Task DeleteCar(Guid carId);
}