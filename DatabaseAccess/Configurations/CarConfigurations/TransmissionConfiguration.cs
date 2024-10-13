using DatabaseAccess.Entities.CarEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAccess.Configurations.CarConfigurations;

public class TransmissionConfiguration : IEntityTypeConfiguration<TransmissionEntity>
{
    public void Configure(EntityTypeBuilder<TransmissionEntity> builder)
    {
        builder.HasKey(t => t.Id);
        builder.ToTable("Transmissions");
    }
}
