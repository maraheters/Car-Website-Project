namespace DatabaseAccess.Entities.CarEntities
{
    public class ImageInfoEntity
    {
        public Guid Id {get; set;}

        public List<string> Urls {get; set;} = [];

        public Guid CarId {get;set;}
        public CarEntity? Car {get;set;}
    }
}