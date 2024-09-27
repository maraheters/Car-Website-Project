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
            .ToListAsync();
    }

    public async Task<CarEntity?> GetById(Guid id)
    {
        return await _dbContext.Cars
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<List<CarEntity>> GetByManufacturer(string manufacturer)
    {
        var query = _dbContext.Cars.AsNoTracking();

        if (!string.IsNullOrEmpty(manufacturer))
        {
            query = query.Where(c => c.Manufacturer.Name == manufacturer);
        }
        
        return await query.ToListAsync();
    }

    
    
}