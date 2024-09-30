
namespace DatabaseAccess.Entities.CarEntities
{
    public class CarEntity
    {
        public Guid Id { get; set; }

        public string Model {get; set;} = string.Empty;
        public decimal Price { get; set; }
        public int Mileage {get; set;} 
        public int Year {get; set;}

        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity? Manufacturer { get;set; }
        
        public Guid CategoryId {get; set;}
        public CategoryEntity? Category {get; set;}

        public Guid ImageInfoId { get; set; }
        public ImageInfoEntity? Images {get;set;}
    }
}