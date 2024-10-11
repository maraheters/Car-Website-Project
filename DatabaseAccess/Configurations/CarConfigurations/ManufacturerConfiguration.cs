
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DatabaseAccess.Entities.CarEntities;

namespace DatabaseAccess.Configurations.CarConfigurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(m => m.Name).IsUnique();
            builder.ToTable("Manufacturers");
        }
    }
}