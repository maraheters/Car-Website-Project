namespace Server.Models.DTOs.PostDtos;

public class PostCarDto
{
    public required string Model { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public int Year { get; set; }
    public required string Manufacturer { get; set; }
    public string Category { get; set; }
    public List<string> Images { get; set; }
}