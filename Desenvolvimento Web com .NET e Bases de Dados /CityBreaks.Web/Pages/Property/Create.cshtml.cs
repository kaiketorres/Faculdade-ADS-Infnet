using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityBreaks.Web.Models;
using CityBreaks.Web.Data;
using CityBreaks.Web.Services;

using ModelsCity = CityBreaks.Web.Models.City;

namespace CityBreaks.Web.Pages.Property
{
    public class CreateModel : PageModel
    {
        private readonly CityBreaksContext _context;
        private readonly ICityService _cityService;

        public CreateModel(CityBreaksContext context, ICityService cityService)
        {
            _context = context;
            _cityService = cityService;
        }

        [BindProperty]
        public Models.Property Property { get; set; } = new Models.Property();

        // Mude esta linha:
        public SelectList CitiesSelectList { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>()); // <<<<< ADICIONE ESTA INICIALIZAÇÃO

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulateCitiesSelectList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Property.City");
            ModelState.Remove("Property.Id");

            if (!ModelState.IsValid)
            {
                await PopulateCitiesSelectList();
                return Page();
            }

            _context.Properties.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        private async Task PopulateCitiesSelectList()
        {
            var cities = await _cityService.GetAllAsync();
            CitiesSelectList = new SelectList(cities, "Id", "Name");
        }
    }
}