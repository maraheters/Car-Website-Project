using Microsoft.EntityFrameworkCore;
using DatabaseAccess.Entities.CarEntities;
using DatabaseAccess.Configurations.CarConfigurations;

namespace DatabaseAccess
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {}

        public DbSet<CarEntity> Cars {get;set;}
        public DbSet<CategoryEntity> Categories {get;set;}
        public DbSet<ImageInfoEntity> Images {get;set;}
        public DbSet<ManufacturerEntity> Manufacturers {get;set;}
        public DbSet<EngineEntity> Engines {get;set;}
        public DbSet<TransmissionEntity> Transmissions {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new EngineConfiguration());
            modelBuilder.ApplyConfiguration(new TransmissionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}