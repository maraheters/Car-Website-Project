using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DatabaseAccess.Entities.CarEntities;

namespace DatabaseAccess.Configurations.CarConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Categories");
        }
    }
}