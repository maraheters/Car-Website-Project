namespace DatabaseAccess.Entities.CarEntities
{
    public class ImageEntity
    {
        public Guid Id {get; set;}

        public string Url {get; set;} = string.Empty;
        public bool IsPrimary {get; set;}

        public Guid CarId {get;set;}
        public CarEntity? Car {get;set;}
    }
}