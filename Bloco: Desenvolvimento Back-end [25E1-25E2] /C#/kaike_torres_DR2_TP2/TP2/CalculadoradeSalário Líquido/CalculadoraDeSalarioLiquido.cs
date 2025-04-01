
using System;

class CalculadoraDeSalarioLiquido {
    static void Main() {
        Console.Write("Digite o salário bruto: ");
        double salarioBruto = double.Parse(Console.ReadLine());
        double descontos = 0;
        if (salarioBruto <= 1500) descontos = salarioBruto * 0.05;
        else if (salarioBruto <= 4000) descontos = salarioBruto * 0.1;
        else descontos = salarioBruto * 0.2;
        double salarioLiquido = salarioBruto - descontos;
        Console.WriteLine($"Salário Bruto: {salarioBruto:F2}Descontos: {descontos:F2}Salário Líquido: {salarioLiquido:F2}");
    }
}
