using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Models; 

namespace AgenciaTurismo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private static List<string> _memoryLogs = new List<string>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

      
        public string LatestLogMessage { get; set; } = string.Empty;
        public List<string> AllMemoryLogs => _memoryLogs;
        public Action<string>? LogOperation; 

      
        [BindProperty]
        public int NumeroDiarias { get; set; }
        [BindProperty]
        public decimal ValorDiaria { get; set; }
        public decimal ValorTotalReserva { get; set; }

       
        [BindProperty]
        public int PacoteIdParaSimularReserva { get; set; } = 1; 
        public int NumeroReservasSimuladas { get; set; } = 1; 

        public string CapacidadeStatusMessage { get; set; } = string.Empty;

      
        public static PacoteTuristico _simulatedPackage = new PacoteTuristico
        {
            Id = 1,
            Titulo = "Aventura na Amazônia",
            CapacidadeMaxima = 3, 
            DataInicio = DateTime.Today.AddDays(30), 
            Preco = 2500.00m
        };

        public void OnGet()
        {
            NumeroDiarias = 7;
            ValorDiaria = 150.0m;
            ValorTotalReserva = 0.0m;
            LatestLogMessage = "Nenhuma operação de log registrada ainda.";
            CapacidadeStatusMessage = $"Pacote '{_simulatedPackage.Titulo}' - Capacidade: {_simulatedPackage.ParticipantesAtuais}/{_simulatedPackage.CapacidadeMaxima}";
        }

        public void OnPostSimulateReservationCreation()
        {
            string logMessage = $"Operação simulada: Criação de Reserva em {DateTime.Now}";
            LogOperation += LogToConsole;
            LogOperation += LogToFile;
            LogToMemory($"[MEMORY LOG] {DateTime.Now}: {logMessage}"); 
            LogOperation?.Invoke(logMessage);
            LatestLogMessage = $"Log Registrado: {logMessage}";
            LogOperation = null; 
        }

        public void OnPostCalculateReservationTotal()
        {
            Func<int, decimal, decimal> calculateReservationTotal =
                (diarias, valor) => diarias * valor;
            ValorTotalReserva = calculateReservationTotal(NumeroDiarias, ValorDiaria);
            _logger.LogInformation($"[FUNC DEMO] Calculado: {NumeroDiarias} diárias * {ValorDiaria:C} = {ValorTotalReserva:C}");
        }

        public void OnPostSimulateCapacityCheck()
        {
            
            _simulatedPackage.CapacityReached += OnCapacityReached;

           
            for (int i = 0; i < NumeroReservasSimuladas; i++)
            {
                _simulatedPackage.AdicionarReservaSimulada(new Reserva
                {
                    ClienteId = 99, 
                    PacoteTuristicoId = _simulatedPackage.Id,
                    DataReserva = DateTime.Now
                });
                _logger.LogInformation($"Simulada adição de reserva ao pacote '{_simulatedPackage.Titulo}'. Participantes: {_simulatedPackage.ParticipantesAtuais}");
            }

            CapacidadeStatusMessage = $"Pacote '{_simulatedPackage.Titulo}' - Capacidade: {_simulatedPackage.ParticipantesAtuais}/{_simulatedPackage.CapacidadeMaxima}";

           
            _simulatedPackage.CapacityReached -= OnCapacityReached;
        }

        
        private void OnCapacityReached(PacoteTuristico pacote)
        {
            string alertMessage = $"ALERTA DE CAPACIDADE! O pacote '{pacote.Titulo}' ({pacote.Id}) atingiu ou excedeu sua capacidade máxima de {pacote.CapacidadeMaxima} participantes.";
            _logger.LogWarning($"[EVENTO DE CAPACIDADE] {alertMessage}");
            Console.WriteLine($"[EVENTO DE CAPACIDADE] {alertMessage}"); 
            CapacidadeStatusMessage = alertMessage; 
        }

                private void LogToConsole(string message)
        {
            _logger.LogInformation($"[CONSOLE LOG] {message}");
            Console.WriteLine($"[CONSOLE LOG] {message}");
        }

        private void LogToFile(string message)
        {
            string logFilePath = "app_operations.log";
            try
            {
                System.IO.File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
                _logger.LogInformation($"[FILE LOG] Log salvo em {logFilePath}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"[FILE LOG ERROR] Erro ao escrever no arquivo de log: {ex.Message}");
            }
        }

        private void LogToMemory(string message)
        {
            _memoryLogs.Add(message); // Já adicionei o "[MEMORY LOG]" no método de chamada
            _logger.LogInformation($"[MEMORY LOG] Log adicionado à memória.");
        }
    }
}
