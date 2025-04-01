using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
        DateTime dataNascimento;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
        {
            Console.Write("Formato inválido. Digite novamente (dd/MM/yyyy): ");
        }

        DateTime hoje = DateTime.Now;
        DateTime aniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

        if (aniversario < hoje)
        {
            aniversario = aniversario.AddYears(1);
        }

        int diasFaltando = (aniversario - hoje).Days;

        if (diasFaltando < 7)
        {
            Console.WriteLine($"Faltam {diasFaltando} dias para o seu próximo aniversário! Que legal, está quase lá!");
        }
        else
        {
            Console.WriteLine($"Faltam {diasFaltando} dias para o seu próximo aniversário.");
        }
    }
}