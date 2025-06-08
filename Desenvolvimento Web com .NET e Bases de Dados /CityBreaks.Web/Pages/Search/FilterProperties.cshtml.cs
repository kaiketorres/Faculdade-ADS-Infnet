using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // Para SelectList
using System.ComponentModel.DataAnnotations; // Para [Display]

using CityBreaks.Web.Models; // Para Property
using CityBreaks.Web.Services;

using ModelsCity = CityBreaks.Web.Models.City;
using ModelsProperty = CityBreaks.Web.Models.Property; // Alias para Property

namespace CityBreaks.Web.Pages.Search
{
    [BindProperties(SupportsGet = true)]
    public class FilterPropertiesModel : PageModel
    {
        private readonly ICityService _cityService;

        public FilterPropertiesModel(ICityService cityService)
        {
            _cityService = cityService;
            // <<<< AQUI: Inicializa CitiesSelectList no construtor
            CitiesSelectList = new SelectList(Enumerable.Empty<SelectListItem>());
        }

        [Display(Name = "Preço Mínimo")]
        public decimal? MinPrice { get; set; }
        [Display(Name = "Preço Máximo")]
        public decimal? MaxPrice { get; set; }
        [Display(Name = "Nome da Cidade")]
        public string? CityName { get; set; }
        [Display(Name = "Nome da Propriedade")]
        public string? PropertyName { get; set; }

        public List<ModelsProperty> FilteredProperties { get; set; } = new List<ModelsProperty>();

        // <<<< SEM '?' pois é inicializado no construtor
        public SelectList CitiesSelectList { get; set; } 

        public async Task OnGetAsync()
        {
            await PerformSearchAndPopulateCities();
        }

        public async Task OnPostAsync()
        {
            await PerformSearchAndPopulateCities();
        }

        private async Task PerformSearchAndPopulateCities()
        {
            FilteredProperties = await _cityService.GetFilteredPropertiesAsync(MinPrice, MaxPrice, CityName, PropertyName);

            var allCities = await _cityService.GetAllAsync();
            CitiesSelectList = new SelectList(allCities, "Name", "Name", CityName); 
        }
    }
}