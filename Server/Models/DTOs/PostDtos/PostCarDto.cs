namespace Server.Models.DTOs.PostDtos;

public class PostCarDto
{
    public required string Model { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public int Year { get; set; }
    public string? Color {get; set;}
    public string? Description {get; set;}
    public string? Drivetrain {get; set;}
    
    public string? Category { get; set; }
    public PostImageInfoDto? Images { get; set; }
    public PostEngineDto? Engine { get; set; }
    public string? Manufacturer { get; set; }
    public PostTransmissionDto? Transmission { get; set; }
    
}