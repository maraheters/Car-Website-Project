namespace Server.Models.DTOs.GetDtos;

public class GetManufacturerDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Country { get; set; }
}