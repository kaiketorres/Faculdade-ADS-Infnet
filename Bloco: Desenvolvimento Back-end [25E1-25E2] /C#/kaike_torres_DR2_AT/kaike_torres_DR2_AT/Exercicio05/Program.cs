using Exercicio05;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        DateTime dataAtual;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataAtual))
        {
            Console.Write("Formato inválido. Digite novamente (dd/MM/yyyy): ");
        }

        DateTime dataFormatura = new DateTime(2026, 12, 15);

        CalculadorTempoRestante calculador = new CalculadorTempoRestante
        {
            DataAtual = dataAtual,
            DataFormatura = dataFormatura
        };
        
        
        Console.WriteLine(calculador.CalcularTempoRestante());
    }
}