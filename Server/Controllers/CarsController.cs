using Microsoft.AspNetCore.Mvc;
using Server.Models.DTOs;
using Server.Models.DTOs.GetDtos;
using Server.Models.DTOs.PostDtos;
using Server.Models.DTOs.UpdateDtos;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var carDto = await _carsService.GetById(id);
        return Ok(carDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostCarDto postCarDto)
    {
        var createdEntity = await _carsService.Create(postCarDto);
        return Created($"/api/cars/{createdEntity.Id}", createdEntity);  
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromHeader] Guid id, [FromBody] PostCarDto updateCarDto)
    {   
        await _carsService.Update(id, updateCarDto);
        return Ok(id);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _carsService.Delete(id);
        return new NoContentResult();
    }
}