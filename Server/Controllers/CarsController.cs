using Microsoft.AspNetCore.Mvc;
using Server.Models.DTOs;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;
using Server.Services.Interfaces;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : Controller
{
    private readonly ICarsService _carsService;

    public CarsController(ICarsService carsService)
    {
        _carsService = carsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var carDtos = await _carsService.GetAll();
        return Ok(carDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostCarDto postCarDto)
    {
        var createdEntity = await _carsService.CreateCar(postCarDto);
        return Created($"/api/cars/{createdEntity.Id}", createdEntity);  
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMovie(Guid id)
    {
        await _carsService.DeleteCar(id);
        return new NoContentResult();
    }
}