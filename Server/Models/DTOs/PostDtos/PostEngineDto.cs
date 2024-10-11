namespace Server.Models.DTOs.PostDtos;

public class PostEngineDto
{
    public required string Model { get; set; }
    public decimal Displacement { get; set; }
    public int Power { get; set; }  
    public int Torque { get; set; } 
    public required string FuelType { get; set; }
    public required string Type { get; set; }    
    public string? Modifications { get; set; } 
}