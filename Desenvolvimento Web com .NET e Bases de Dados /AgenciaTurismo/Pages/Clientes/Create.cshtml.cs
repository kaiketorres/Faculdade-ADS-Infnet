using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Data; // Para acessar o DbContext
using AgenciaTurismo.Models; // Para acessar a entidade Cliente


namespace AgenciaTurismo.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;
        private readonly ILogger<CreateModel> _logger; // Para logs

        public CreateModel(AgenciaTurismoContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Propriedade para vincular os dados do formulário ao modelo Cliente
        [BindProperty]
        public Cliente Cliente { get; set; } = default!; // 'default!' para evitar aviso CS8618

        public IActionResult OnGet()
        {
            // Inicializa uma nova instância de Cliente para o formulário
            Cliente = new Cliente();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("Attempting to create a new client.");

            // Verifica se o modelo do formulário é válido com base nas Data Annotations
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid. Errors: {Errors}",
                    string.Join("; ", ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)));
                return Page(); // Retorna a mesma página com as mensagens de erro
            }

            try
            {
                // Adiciona o novo cliente ao contexto do Entity Framework
                _context.Clientes.Add(Cliente);
                // Salva as mudanças no banco de dados
                await _context.SaveChangesAsync();
                _logger.LogInformation("Client '{Nome}' created successfully with ID: {Id}", Cliente.Nome, Cliente.Id);

                // Redireciona para a página inicial ou para uma lista de clientes
                return RedirectToPage("/Index"); // Você pode mudar para uma página de lista de clientes depois
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating client '{Nome}'", Cliente.Nome);
                // Adiciona um erro genérico ao ModelState para exibir na página
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar o cliente. Tente novamente.");
                return Page();
            }
        }
    }
}
