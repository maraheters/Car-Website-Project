namespace DatabaseAccess.Entities.CarEntities;

public class EngineEntity
{
    public Guid Id { get; set; }
    
    public string Model { get; set; }
    public decimal Displacement { get; set; }
    public int Power { get; set; }  //in kW
    public int Torque { get; set; } //in Nm
    public string FuelType { get; set; }
    public string Type { get; set; }    //e.g. inline, v6, v8
    public string? Modifications { get; set; }  //optional modifications
    
    public Guid CarId { get; set; }
    public CarEntity? Car { get; set; }
    
}