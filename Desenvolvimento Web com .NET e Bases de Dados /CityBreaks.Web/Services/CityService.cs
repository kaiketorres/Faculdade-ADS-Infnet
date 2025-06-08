using ModelsCity = CityBreaks.Web.Models.City;

namespace CityBreaks.Web.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;

        public CityService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<ModelsCity>> GetAllAsync()
        {
            return await _context.Cities
                                 .Include(c => c.Country)
                                 .Include(c => c.Properties.Where(p => p.DeletedAt == null))
                                 .OrderBy(c => c.Name)
                                 .ToListAsync();
        }

        public async Task<ModelsCity?> GetByNameAsync(string name)
        {
            return await _context.Cities
                                 .Include(c => c.Country)
                                 .Include(c => c.Properties.Where(p => p.DeletedAt == null))
                                 .FirstOrDefaultAsync(c => EF.Functions.Collate(c.Name, "NOCASE") == EF.Functions.Collate(name, "NOCASE"));
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties
                                 .Include(p => p.City)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeletePropertyAsync(int id)
        {
            var propertyToDelete = await _context.Properties.FindAsync(id);
            if (propertyToDelete != null)
            {
                propertyToDelete.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

       
        public async Task<List<Property>> GetFilteredPropertiesAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName)
        {
           
            IQueryable<Property> query = _context.Properties
                                                .Include(p => p.City)      
                                                .Include(p => p.City!.Country) 
                                                .Where(p => p.DeletedAt == null); 
            
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight <= maxPrice.Value);
            }

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                
                query = query.Where(p => EF.Functions.Collate(p.City!.Name, "NOCASE").Contains(EF.Functions.Collate(cityName, "NOCASE")));
            }

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                
                query = query.Where(p => EF.Functions.Collate(p.Name, "NOCASE").Contains(EF.Functions.Collate(propertyName, "NOCASE")));
            }

            
            return await query.OrderBy(p => p.Name).ToListAsync();
        }
    }
}