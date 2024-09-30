using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Server.Models.DTOs;
using Server.Models.DTOs.GetDtos;
using Server.Services.Interfaces;

namespace Server.Controllers;

public class HomeController : Controller
{
    private readonly ICarsService _service;
    public HomeController(ICarsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCarDto>>> GetAllCars()
    {
        var carDtos = await _service.GetAll();
        return Ok(carDtos);
    }
}