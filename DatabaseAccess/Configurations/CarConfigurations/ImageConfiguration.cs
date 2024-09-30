using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DatabaseAccess.Entities.CarEntities;

namespace DatabaseAccess.Configurations.CarConfigurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageInfoEntity>
    {
        public void Configure(EntityTypeBuilder<ImageInfoEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder
                .HasOne(i => i.Car)
                .WithOne(c => c.Images).HasForeignKey<CarEntity>(c => c.ImageInfoId);
        }
    }
}