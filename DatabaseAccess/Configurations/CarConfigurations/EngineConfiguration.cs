using DatabaseAccess.Entities.CarEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAccess.Configurations.CarConfigurations;

public class EngineConfiguration : IEntityTypeConfiguration<EngineEntity>
{
    public void Configure(EntityTypeBuilder<EngineEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.ToTable("Engines");
    }
}