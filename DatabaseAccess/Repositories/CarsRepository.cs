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
            .Include(c => c.Engine)
            .Include(c => c.Transmission)
            .ToListAsync();
    }

    public async Task<CarEntity?> GetById(Guid id)
    {
        return await _dbContext.Cars
            .AsNoTracking()
            .Include(c => c.Manufacturer)
            .Include(c => c.Category)
            .Include(c => c.Images)
            .Include(c => c.Engine)
            .Include(c => c.Transmission)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Create(CarEntity car, string manufacturerName, string categoryName)
    {
        car.Id = Guid.NewGuid();

        var manufacturerTask = GetOrCreateManufacturer(manufacturerName);
        var categoryTask = GetOrCreateCategory(categoryName);

        var manufacturer = await manufacturerTask;
        var category = await categoryTask;
        
        manufacturer.Cars.Add(car);
        category.Cars.Add(car);
        
        car.Manufacturer = manufacturer;
        car.Category = category;
        
        await _dbContext.Cars.AddAsync(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(CarEntity car)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(CarEntity car)
    {
        _dbContext.Remove(car);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<ManufacturerEntity> GetOrCreateManufacturer(string manufacturerName)
    {
        var manufacturerNameCapitalized = Capitalize(manufacturerName);
        var manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(m => m.Name == manufacturerNameCapitalized);
        if (manufacturer == null)
        {
            manufacturer = new ManufacturerEntity 
            { 
                Id = Guid.NewGuid(), 
                Cars = [], 
                Name = manufacturerNameCapitalized
            };
            await _dbContext.Manufacturers.AddAsync(manufacturer);
        }

        return manufacturer;
    }

    private async Task<CategoryEntity> GetOrCreateCategory(string categoryName)
    {
        var categoryNameCapitalized = Capitalize(categoryName);
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == categoryNameCapitalized);
        if (category == null)
        {
            category = new CategoryEntity
            {
                Id = Guid.NewGuid(), 
                Cars = [], 
                Name = categoryNameCapitalized
            };
            await _dbContext.Categories.AddAsync(category);
        }
        
        return category;
    }
    
    private string Capitalize(string s) => 
        string.IsNullOrEmpty(s) ? string.Empty : char.ToUpper(s[0]) + s.Substring(1);
}