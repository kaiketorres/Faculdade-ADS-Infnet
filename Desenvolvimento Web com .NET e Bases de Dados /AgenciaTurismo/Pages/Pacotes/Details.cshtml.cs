using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Data;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Pages.Pacotes
{
    public class DetailsModel : PageModel
    {
        private readonly AgenciaTurismo.Data.AgenciaTurismoContext _context;

        public DetailsModel(AgenciaTurismo.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public PacoteTuristico? PacoteTuristico { get; set; } // Correção CS8601: Propriedade anulável

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca o pacote, incluindo as cidades de destino
            // Corrigido CS8601: Verifica se o resultado é nulo antes de atribuir
            PacoteTuristico = await _context.PacotesTuristico
                .Include(p => p.CidadesDestino)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PacoteTuristico == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
