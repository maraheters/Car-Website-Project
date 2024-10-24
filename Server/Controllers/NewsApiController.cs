using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly NewsApiClient _newsApiClient;
    private readonly string? API_KEY;

    public NewsController(IConfiguration config)
    {
        API_KEY = config["News:NewsApiKey"];
        _newsApiClient = new NewsApiClient(API_KEY);
    }

    [HttpGet("{page}, {pageSize}")]
    public async Task<IActionResult> GetAllWithPaging(int page, int pageSize)
    {
        if (page < 1)
        {
            return BadRequest("Page number must be greater than 0.");
        }

        if (pageSize < 1 || pageSize > 100) 
        {
            return BadRequest("Page size must be between 1 and 100.");
        }

        DateTime? from = DateTime.Today.AddMonths(-1);   

        var articlesResponse = await _newsApiClient.GetEverythingAsync(new EverythingRequest
        {
            Q = "cars",
            SortBy = SortBys.Relevancy,
            Language = Languages.EN,
            From = from,
            Page = page,
            PageSize = pageSize,
        });

        if (articlesResponse.Status != Statuses.Ok)
        {
            return StatusCode(500, "Error retrieving articles.");
        }

        return Ok(new
        {
            articlesResponse.TotalResults,
            articlesResponse.Articles
        });
    }
}
