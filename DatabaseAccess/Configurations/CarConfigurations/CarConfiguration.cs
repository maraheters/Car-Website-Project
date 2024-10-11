using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DatabaseAccess.Entities.CarEntities;

namespace DatabaseAccess.Configurations.CarConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Manufacturer)
                .WithMany(m => m.Cars);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars);

            builder
                .HasOne(c => c.Images)
                .WithOne(i => i.Car)
                .HasForeignKey<ImageInfoEntity>(i => i.CarId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(c => c.Engine)
                .WithOne(e => e.Car)
                .HasForeignKey<EngineEntity>(e => e.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}