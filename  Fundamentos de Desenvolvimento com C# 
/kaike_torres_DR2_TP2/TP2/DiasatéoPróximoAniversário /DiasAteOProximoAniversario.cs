
using System;

class DiasAteOProximoAniversario {
    static void Main() {
        Console.Write("Digite sua data de nascimento (dd/mm/yyyy): ");
        DateTime nascimento = DateTime.Parse(Console.ReadLine());
        DateTime hoje = DateTime.Today;
        DateTime proximoAniversario = new DateTime(hoje.Year, nascimento.Month, nascimento.Day);
        if (hoje > proximoAniversario) proximoAniversario = proximoAniversario.AddYears(1);
        int diasRestantes = (proximoAniversario - hoje).Days;
        Console.WriteLine($"Faltam {diasRestantes} dias para o seu próximo aniversário.");
    }
}
