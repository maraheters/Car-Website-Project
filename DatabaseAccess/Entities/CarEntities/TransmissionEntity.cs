namespace DatabaseAccess.Entities.CarEntities;

public class TransmissionEntity
{
    public Guid Id { get; set; }
    
    public string GearboxType { get; set; } //e.g automatic, manual, cvt
    public int? NumberOfGears { get; set; }
    
    public Guid CarId { get; set; }
    public CarEntity? Car { get; set; }
}