
namespace DatabaseAccess.Entities.CarEntities
{
    public class CategoryEntity
    {
        public Guid Id {get;set;}

        public string Name {get;set;} = string.Empty;

        public List<CarEntity> Cars {get;set;} = [];
    }
}