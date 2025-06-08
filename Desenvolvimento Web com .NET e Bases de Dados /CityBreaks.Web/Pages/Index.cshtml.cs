using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Models; 
using CityBreaks.Web.Services; 

namespace CityBreaks.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICityService _cityService; 

        public IndexModel(ILogger<IndexModel> logger, ICityService cityService) 
        { 
            _logger = logger;
            _cityService = cityService;
        }

       public List<CityBreaks.Web.Models.City> Cities { get; set; } = new List<CityBreaks.Web.Models.City>();

        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllAsync();
        }
    }
}