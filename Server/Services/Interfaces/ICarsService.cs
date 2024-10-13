using Server.Models.DTOs;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;
using Server.Models.DTOs.UpdateDtos;

namespace Server.Services.Interfaces;

public interface ICarsService
{
    public Task<List<GetCarDto>> GetAll();
    public Task<GetCarDto> GetById(Guid carId);
    
    public Task<GetCarDto> Create(PostCarDto postCarDto);
    public Task Update(Guid carId, PostCarDto updateCarDto);
    public Task Delete(Guid carId);
}