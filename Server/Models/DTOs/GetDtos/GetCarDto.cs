namespace Server.Models.DTOs.GetDtos;

public class GetCarDto
{
    public Guid Id { get; set; }
    public required string Model { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public int Year { get; set; }
    public string? Color {get; set;}
    public string? Description {get; set;}
    public string? Drivetrain {get; set;}
    
    public string? Category { get; set; }
    public GetImageInfoDto? Images { get; set; }
    public GetEngineDto? Engine { get; set; }
    public GetManufacturerDto? Manufacturer { get; set; }
    public GetTransmissionDto? Transmission { get; set; }
}