
namespace DatabaseAccess.Entities.CarEntities
{
    public class CarEntity
    {
        public Guid Id { get; set; }

        public string Model {get; set;} = string.Empty;
        public decimal Price { get; set; }
        public int Mileage {get; set;} 
        public int Year {get; set;}
        public string Color {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string Drivetrain {get; set;} = string.Empty;
        
        public ManufacturerEntity? Manufacturer { get;set; }
        public CategoryEntity? Category {get; set;}
        public ImageInfoEntity? Images {get;set;}
        public EngineEntity? Engine {get; set;}
        public TransmissionEntity? Transmission {get; set;}
    }
}