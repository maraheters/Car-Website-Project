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
    public required string Manufacturer { get; set; }
    public string? Category { get; set; }
    public List<string>? Images { get; set; }
    
    public GetEngineDto? Engine { get; set; }
}