using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Data; // Para acessar o DbContext
using AgenciaTurismo.Models; // Para acessar a entidade PacoteTuristico
using System.Threading.Tasks;

namespace AgenciaTurismo.Pages.Pacotes
{
    public class CreateModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(AgenciaTurismoContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Propriedade para vincular os dados do formulário ao modelo PacoteTuristico
        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public IActionResult OnGet()
        {
            PacoteTuristico = new PacoteTuristico(); // Inicializa uma nova instância
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("Attempting to create a new tourist package.");

            // Verifica as validações definidas no modelo (Data Annotations)
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid for tourist package. Errors: {Errors}",
                    string.Join("; ", ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)));
                return Page(); // Retorna a mesma página com as mensagens de erro
            }

            // Regra de negócio adicional: DataFim não pode ser anterior a DataInicio
            if (PacoteTuristico.DataFim < PacoteTuristico.DataInicio)
            {
                ModelState.AddModelError("PacoteTuristico.DataFim", "A data de fim não pode ser anterior à data de início.");
                _logger.LogWarning("Validation error: End date is before start date.");
                return Page();
            }

            try
            {
                _context.PacotesTuristico.Add(PacoteTuristico);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Tourist package '{Titulo}' created successfully with ID: {Id}", PacoteTuristico.Titulo, PacoteTuristico.Id);

                // Redireciona para a página inicial ou para uma lista de pacotes
                return RedirectToPage("/Index"); // Pode mudar para uma página de lista de pacotes depois
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating tourist package '{Titulo}'", PacoteTuristico.Titulo);
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar o pacote turístico. Tente novamente.");
                return Page();
            }
        }
    }
}
