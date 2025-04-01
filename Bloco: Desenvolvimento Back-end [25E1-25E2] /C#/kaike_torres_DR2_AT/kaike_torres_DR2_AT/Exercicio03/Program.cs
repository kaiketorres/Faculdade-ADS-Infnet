using System;

class Program
{
    static void Main(string[] args)
    {
        double numero1, numero2;
        
        Console.Write("Digite o primeiro número: ");
        while (!double.TryParse(Console.ReadLine(), out numero1))
        {
            Console.Write("Entrada inválida. Digite um número válido: ");
        }

        Console.Write("Digite o segundo número: ");
        while (!double.TryParse(Console.ReadLine(), out numero2))
        {
            Console.Write("Entrada inválida. Digite um número válido: ");
        }

        Console.WriteLine("Escolha a operação:");
        Console.WriteLine("1. Soma");
        Console.WriteLine("2. Subtração");
        Console.WriteLine("3. Multiplicação");
        Console.WriteLine("4. Divisão");
        
        int operacao;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out operacao) && operacao >= 1 && operacao <= 4)
                break;
            Console.Write("Escolha uma operação válida (1-4): ");
        }

        double resultado = 0;

        switch (operacao)
        {
            case 1:
                resultado = numero1 + numero2;
                break;
            case 2:
                resultado = numero1 - numero2;
                break;
            case 3:
                resultado = numero1 * numero2;
                break;
            case 4:
                if (numero2 == 0)
                {
                    Console.WriteLine("Erro: Divisão por zero não é permitida.");
                    return;
                }
                resultado = numero1 / numero2;
                break;
        }

        Console.WriteLine($"Resultado: {resultado}");
    }
}