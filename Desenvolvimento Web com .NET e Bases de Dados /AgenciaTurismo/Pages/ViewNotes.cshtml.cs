using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


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

        
        [BindProperty]
        public string NoteContent { get; set; } = string.Empty;

        
        [BindProperty(SupportsGet = true)] 
        public string? SelectedFileName { get; set; }

       
        public string FileContent { get; set; } = string.Empty;

      
        public List<string> AvailableNotes { get; set; } = new List<string>();

        
        public string StatusMessage { get; set; } = string.Empty;

       
        private string NotesFolderPath => Path.Combine(_env.WebRootPath, "files");

        public IActionResult OnGet()
        {
            LoadAvailableNotes();

            if (!string.IsNullOrEmpty(SelectedFileName))
            {
               
                var safeFileName = Path.GetFileName(SelectedFileName);
                string filePath = Path.Combine(NotesFolderPath, safeFileName);

                if (System.IO.File.Exists(filePath) && safeFileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                       
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

       
            string fileName = $"note_{DateTime.Now:yyyyMMddHHmmss}.txt";
            string filePath = Path.Combine(NotesFolderPath, fileName);

            try
            {
              
                Directory.CreateDirectory(NotesFolderPath);

                await System.IO.File.WriteAllTextAsync(filePath, NoteContent);
                StatusMessage = $"Nota '{fileName}' salva com sucesso!";
                NoteContent = string.Empty; 
                _logger.LogInformation($"Note '{fileName}' saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error saving note '{fileName}'.");
                StatusMessage = $"Erro ao salvar a nota: {ex.Message}";
            }

            LoadAvailableNotes(); 
            return Page();
        }

        private void LoadAvailableNotes()
        {
            AvailableNotes.Clear();
            if (Directory.Exists(NotesFolderPath))
            {
               
                AvailableNotes = Directory.GetFiles(NotesFolderPath, "*.txt")
                                        .Select(Path.GetFileName)
                                        .OfType<string>() 
                                        .ToList();
            }
        }
    }
}
