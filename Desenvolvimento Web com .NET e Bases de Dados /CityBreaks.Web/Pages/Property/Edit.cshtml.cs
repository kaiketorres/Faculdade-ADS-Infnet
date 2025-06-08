
namespace CityBreaks.Web.Pages.Property
{
   
    public class EditModel : PageModel
    {
        private readonly CityBreaksContext _context;
        private readonly ICityService _cityService;

        public EditModel(CityBreaksContext context, ICityService cityService)
        {
            _context = context;
            _cityService = cityService;
        }

        [BindProperty] 
       
        public Models.Property? Property { get; set; }

        
        public SelectList CitiesSelectList { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>()); 

       
        public async Task<IActionResult> OnGetAsync(int? id) 
        {
            if (id == null)
            {
                return NotFound(); 
            }

           
            Property = await _cityService.GetPropertyByIdAsync(id.Value);

            if (Property == null)
            {
                return NotFound(); 
            }

            await PopulateCitiesSelectList(); // Popula o dropdown
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            var propertyToUpdate = await _context.Properties.FindAsync(id);

            if (propertyToUpdate == null)
            {
                return NotFound();
            }

            
            var updated = await TryUpdateModelAsync<Models.Property>(
                                propertyToUpdate,
                                "Property", 
                                p => p.Name,
                                p => p.PricePerNight,
                                p => p.CityId); 

           

            if (updated) 
            {
                try
                {
                    await _context.SaveChangesAsync(); 
                }
                catch (DbUpdateConcurrencyException) 
                {
                    if (!await _context.Properties.AnyAsync(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; 
                    }
                }

                return RedirectToPage("/City/Details", new { name = propertyToUpdate.City?.Name });
            }

            await PopulateCitiesSelectList(); 
            return Page();
        }

        private async Task PopulateCitiesSelectList()
        {
            var cities = await _cityService.GetAllAsync();
            CitiesSelectList = new SelectList(cities, "Id", "Name", Property?.CityId);
        }
    }
}