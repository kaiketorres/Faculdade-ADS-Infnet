using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Data;
using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Authorization; // Adicione este using

namespace AgenciaTurismo.Pages.Pacotes
{
    [Authorize] // Adiciona este atributo para proteger a página
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismo.Data.AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismo.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Filtra para exibir apenas pacotes que NÃO FORAM logicamente excluídos
            PacoteTuristico = await _context.PacotesTuristico
                .Where(p => !p.IsDeleted)
                .ToListAsync();

            return Page();
        }
    }
}
