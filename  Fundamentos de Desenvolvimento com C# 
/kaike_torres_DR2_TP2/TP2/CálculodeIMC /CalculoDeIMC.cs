using System;
using System.Globalization;

class CalculoDeIMC {
    static void Main() {
        Console.Write("Digite seu peso (kg): ");
        double peso;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out peso) || peso <= 0) {
            Console.WriteLine("Entrada inválida! Digite um valor numérico positivo.");
        }

        Console.Write("Digite sua altura (m): ");
        double altura;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out altura) || altura <= 0) {
            Console.WriteLine("Entrada inválida! Digite um valor numérico positivo.");
        }

        double imc = peso / (altura * altura);

        string classificacao = imc < 18.5 ? "Abaixo do peso" :
            imc < 24.9 ? "Peso normal" :
            imc < 29.9 ? "Sobrepeso" : "Obesidade";

        Console.WriteLine($"Seu IMC é {imc:F2}. Classificação: {classificacao}.");
    }
}