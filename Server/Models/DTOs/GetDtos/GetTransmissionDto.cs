namespace Server.Models.DTOs.GetDtos;

public class GetTransmissionDto
{
    public Guid Id { get; set; }
    
    public string GearboxType { get; set; } //e.g automatic, manual, cvt
    public int? NumberOfGears { get; set; }
    
    public Guid CarId { get; set; }
}