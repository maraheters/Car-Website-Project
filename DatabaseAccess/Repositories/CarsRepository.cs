using DatabaseAccess.Entities.CarEntities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Repositories;

public class CarsRepository
{
    private readonly CarDbContext _dbContext;

    public CarsRepository(CarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CarEntity>> GetAll()
    {
        return await _dbContext.Cars
            .AsNoTracking()
            .Include(c => c.Manufacturer)
            .Include(c => c.Category)
            .Include(c => c.Images)
            .ToListAsync();
    }

    public async Task<CarEntity?> GetById(Guid id)
    {
        return await _dbContext.Cars
            .AsNoTracking()
            .Include(c => c.Manufacturer)
            .Include(c => c.Category)
            .Include(c => c.Images)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Create(CarEntity car, string manufacturerName, string categoryName)
    {
        var id = Guid.NewGuid();
        
        var manufacturer = _dbContext.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
        if (manufacturer == null)
        {
            manufacturer = new ManufacturerEntity { Id = Guid.NewGuid(), Cars = [], Name = manufacturerName };
            _dbContext.Manufacturers.Add(manufacturer);
        }
        manufacturer.Cars.Add(car);
        
        var category = _dbContext.Categories.FirstOrDefault(c => c.Name == categoryName);
        if (category == null)
        {
            category = new CategoryEntity { Id = Guid.NewGuid(), Cars = [], Name = categoryName };
            _dbContext.Categories.Add(category);
        }
        category.Cars.Add(car);

        var images = car.Images;
        images.Id = Guid.NewGuid();
        images.Car = car;

        car.Id = id;
        car.Manufacturer = manufacturer;
        car.Category = category;
        car.Images = images;
        
        await _dbContext.Cars.AddAsync(car);
        await _dbContext.SaveChangesAsync();
    }
    
    // public async Task<List<CarEntity>> GetByManufacturer(string manufacturer)
    // {
    //     var query = _dbContext.Cars.AsNoTracking();
    //
    //     if (!string.IsNullOrEmpty(manufacturer))
    //     {
    //         query = query.Where(c => c.Manufacturer.Name == manufacturer);
    //     }
    //     
    //     return await query.ToListAsync();
    // }

    
    
}