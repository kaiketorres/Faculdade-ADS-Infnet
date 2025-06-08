using CityBreaks.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using ModelsCity = CityBreaks.Web.Models.City;

namespace CityBreaks.Web.Services
{
    public interface ICityService
    {
        Task<List<ModelsCity>> GetAllAsync();
        Task<ModelsCity?> GetByNameAsync(string name);
        Task<Property?> GetPropertyByIdAsync(int id);
        Task DeletePropertyAsync(int id);

       
        Task<List<Property>> GetFilteredPropertiesAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName);
    }
}