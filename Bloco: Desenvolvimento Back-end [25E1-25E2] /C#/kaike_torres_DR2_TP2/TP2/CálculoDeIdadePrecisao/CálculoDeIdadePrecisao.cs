
using System;

class CálculoDeIdadePrecisao {
    static void Main() {
        Console.Write("Digite sua data de nascimento (dd/mm/yyyy): ");
        DateTime nascimento = DateTime.Parse(Console.ReadLine());
        DateTime hoje = DateTime.Today;
        int idadeAnos = hoje.Year - nascimento.Year;
        if (hoje < nascimento.AddYears(idadeAnos)) idadeAnos--;
        int idadeMeses = hoje.Month - nascimento.Month;
        if (hoje.Month < nascimento.Month) idadeMeses += 12;
        int idadeDias = hoje.Day - nascimento.Day;
        if (hoje.Day < nascimento.Day) idadeDias += DateTime.DaysInMonth(hoje.Year, hoje.Month);
        Console.WriteLine($"Sua idade é {idadeAnos} anos, {idadeMeses} meses e {idadeDias} dias.");
    }
}
