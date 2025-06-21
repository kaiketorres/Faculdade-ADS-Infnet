using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting; // Para acessar o ambiente de hospedagem e o caminho wwwroot
using System.IO; // Para operações de arquivo
using System.Collections.Generic; // Para List
using System.Linq; // Para Where, Select, etc.
using System.Threading.Tasks; // Para Task

namespace AgenciaTurismo.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ViewNotesModel> _logger;

        public ViewNotesModel(IWebHostEnvironment env, ILogger<ViewNotesModel> logger)
        {
            _env = env;
            _logger = logger;
        }

        // Propriedade para vincular o conteúdo da nova nota
        [BindProperty]
        public string NoteContent { get; set; } = string.Empty;

        // Propriedade para armazenar o nome do arquivo a ser visualizado
        [BindProperty(SupportsGet = true)] // Permite que seja vinculado via URL (query string)
        public string? SelectedFileName { get; set; }

        // Propriedade para exibir o conteúdo do arquivo selecionado
        public string FileContent { get; set; } = string.Empty;

        // Propriedade para listar os arquivos de notas existentes
        public List<string> AvailableNotes { get; set; } = new List<string>();

        // Propriedade para mensagens de status
        public string StatusMessage { get; set; } = string.Empty;

        // Caminho absoluto para a pasta de arquivos
        private string NotesFolderPath => Path.Combine(_env.WebRootPath, "files");

        public IActionResult OnGet()
        {
            LoadAvailableNotes(); // Carrega a lista de arquivos ao carregar a página

            if (!string.IsNullOrEmpty(SelectedFileName))
            {
                // Limpeza do nome do arquivo para evitar Path Traversal (segurança)
                var safeFileName = Path.GetFileName(SelectedFileName);
                string filePath = Path.Combine(NotesFolderPath, safeFileName);

                if (System.IO.File.Exists(filePath) && safeFileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        // Lê o conteúdo do arquivo
                        FileContent = System.IO.File.ReadAllText(filePath);
                        _logger.LogInformation($"File '{safeFileName}' content loaded successfully.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error reading file '{safeFileName}'.");
                        StatusMessage = $"Erro ao ler o arquivo: {ex.Message}";
                        FileContent = string.Empty;
                    }
                }
                else
                {
                    StatusMessage = $"Arquivo '{safeFileName}' não encontrado ou formato inválido (.txt esperado).";
                    FileContent = string.Empty;
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSaveNoteAsync()
        {
            if (string.IsNullOrWhiteSpace(NoteContent))
            {
                StatusMessage = "O conteúdo da nota não pode ser vazio.";
                LoadAvailableNotes();
                return Page();
            }

            // Gera um nome de arquivo único
            string fileName = $"note_{DateTime.Now:yyyyMMddHHmmss}.txt";
            string filePath = Path.Combine(NotesFolderPath, fileName);

            try
            {
                // Garante que o diretório exista
                Directory.CreateDirectory(NotesFolderPath);

                // Salva o conteúdo no arquivo
                await System.IO.File.WriteAllTextAsync(filePath, NoteContent);
                StatusMessage = $"Nota '{fileName}' salva com sucesso!";
                NoteContent = string.Empty; // Limpa o campo de texto
                _logger.LogInformation($"Note '{fileName}' saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error saving note '{fileName}'.");
                StatusMessage = $"Erro ao salvar a nota: {ex.Message}";
            }

            LoadAvailableNotes(); // Recarrega a lista de arquivos após salvar
            return Page();
        }

        private void LoadAvailableNotes()
        {
            AvailableNotes.Clear();
            if (Directory.Exists(NotesFolderPath))
            {
                // Lista apenas arquivos .txt
                AvailableNotes = Directory.GetFiles(NotesFolderPath, "*.txt")
                                        .Select(Path.GetFileName)
                                        .OfType<string>() // Garante que é uma lista de strings
                                        .ToList();
            }
        }
    }
}
