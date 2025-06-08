using ModelsCity = CityBreaks.Web.Models.City;

namespace CityBreaks.Web.Pages.City
{
   
    [BindProperties(SupportsGet = true)] 
    public class DetailsModel : PageModel
    {
        private readonly ICityService _cityService;

        public DetailsModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public ModelsCity? City { get; set; } 

       
        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound(); 
            }

            City = await _cityService.GetByNameAsync(name); 

            if (City == null)
            {
                return NotFound(); 
            }

            return Page(); 
        }

        
        public async Task<IActionResult> OnPostDeleteAsync(int id, string cityName)
        {
            await _cityService.DeletePropertyAsync(id); // Chama o serviço para exclusão lógica

           
            return RedirectToPage("/City/Details", new { name = cityName });
        }
    }
}