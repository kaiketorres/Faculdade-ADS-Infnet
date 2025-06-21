using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Authorization; // Adicionado para [Authorize]

namespace AgenciaTurismo.Pages.Pacotes
{
    [Authorize] // Protege esta página
    public class DeleteModel : PageModel
    {
        private readonly AgenciaTurismo.Data.AgenciaTurismoContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(AgenciaTurismo.Data.AgenciaTurismoContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public PacoteTuristico? PacoteTuristico { get; set; } // Correção CS8601: Propriedade anulável

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca o pacote, incluindo cidades para exibição na tela de confirmação
            // Corrigido CS8601: Verifica se o resultado é nulo antes de atribuir
            PacoteTuristico = await _context.PacotesTuristico
                .Include(p => p.CidadesDestino)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PacoteTuristico == null)
            {
                _logger.LogWarning("Package with ID {Id} not found for deletion confirmation.", id);
                return NotFound();
            }
            _logger.LogInformation("Loaded package ID {Id} for logical deletion confirmation.", id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacote = await _context.PacotesTuristico.FindAsync(id);

            if (pacote != null)
            {
                // Implementação da Exclusão Lógica:
                pacote.IsDeleted = true; // Define a propriedade IsDeleted para true
                _context.PacotesTuristico.Update(pacote); // Marca a entidade como modificada
                await _context.SaveChangesAsync(); // Salva a mudança no banco de dados
                _logger.LogInformation("Package '{Titulo}' (ID: {Id}) logically deleted.", pacote.Titulo, pacote.Id);
            }
            else
            {
                _logger.LogWarning("Attempted to logically delete non-existent package with ID {Id}.", id);
            }

            return RedirectToPage("./Index"); // Redireciona para a lista de pacotes
        }
    }
}
