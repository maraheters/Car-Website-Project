namespace Server.Models.DTOs.PostDtos;

public class PostTransmissionDto
{
    public string GearboxType { get; set; } //e.g automatic, manual, cvt
    public int? NumberOfGears { get; set; }
}