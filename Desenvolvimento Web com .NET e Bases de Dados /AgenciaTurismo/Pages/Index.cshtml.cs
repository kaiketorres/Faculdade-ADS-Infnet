using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Collections.Generic;
using AgenciaTurismo.Models; // Importar Models para usar PacoteTuristico e Reserva

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

        // Propriedades para logs (dos itens anteriores)
        public string LatestLogMessage { get; set; } = string.Empty;
        public List<string> AllMemoryLogs => _memoryLogs;
        public Action<string>? LogOperation; // Correção CS8618: Marcado como anulável

        // Propriedades para cálculo com Func (dos itens anteriores)
        [BindProperty]
        public int NumeroDiarias { get; set; }
        [BindProperty]
        public decimal ValorDiaria { get; set; }
        public decimal ValorTotalReserva { get; set; }

        // --- Propriedades para a demonstração do Evento ---
        [BindProperty]
        public int PacoteIdParaSimularReserva { get; set; } = 1; // Para selecionar um pacote
        [BindProperty]
        public int NumeroReservasSimuladas { get; set; } = 1; // Quantas reservas adicionar

        public string CapacidadeStatusMessage { get; set; } = string.Empty;

        // Simulação de um pacote turístico em memória para demonstração do evento
        // Em uma aplicação real, isso viria do banco de dados via EF Core.
        // Correção CS0122: Alterado de private para public static
        public static PacoteTuristico _simulatedPackage = new PacoteTuristico
        {
            Id = 1,
            Titulo = "Aventura na Amazônia",
            CapacidadeMaxima = 3, // Capacidade baixa para facilitar a demonstração
            DataInicio = DateTime.Today.AddDays(30), // Data futura
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
            LogToMemory($"[MEMORY LOG] {DateTime.Now}: {logMessage}"); // Adicionar diretamente
            LogOperation?.Invoke(logMessage);
            LatestLogMessage = $"Log Registrado: {logMessage}";
            LogOperation = null; // Limpa o delegate
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
            // 1. Assinar o evento CapacityReached do pacote simulado
            _simulatedPackage.CapacityReached += OnCapacityReached;

            // 2. Simular a adição de reservas
            for (int i = 0; i < NumeroReservasSimuladas; i++)
            {
                _simulatedPackage.AdicionarReservaSimulada(new Reserva
                {
                    ClienteId = 99, // Cliente fictício
                    PacoteTuristicoId = _simulatedPackage.Id,
                    DataReserva = DateTime.Now
                });
                _logger.LogInformation($"Simulada adição de reserva ao pacote '{_simulatedPackage.Titulo}'. Participantes: {_simulatedPackage.ParticipantesAtuais}");
            }

            CapacidadeStatusMessage = $"Pacote '{_simulatedPackage.Titulo}' - Capacidade: {_simulatedPackage.ParticipantesAtuais}/{_simulatedPackage.CapacidadeMaxima}";

            // 3. Remover a assinatura do evento (boa prática para evitar memory leaks)
            _simulatedPackage.CapacityReached -= OnCapacityReached;
        }

        // 4. Método manipulador do evento (o delegate que será chamado)
        private void OnCapacityReached(PacoteTuristico pacote)
        {
            string alertMessage = $"ALERTA DE CAPACIDADE! O pacote '{pacote.Titulo}' ({pacote.Id}) atingiu ou excedeu sua capacidade máxima de {pacote.CapacidadeMaxima} participantes.";
            _logger.LogWarning($"[EVENTO DE CAPACIDADE] {alertMessage}");
            Console.WriteLine($"[EVENTO DE CAPACIDADE] {alertMessage}"); // Para ver no terminal
            CapacidadeStatusMessage = alertMessage; // Atualiza a mensagem na página
        }

        // Métodos de log (dos itens anteriores)
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
