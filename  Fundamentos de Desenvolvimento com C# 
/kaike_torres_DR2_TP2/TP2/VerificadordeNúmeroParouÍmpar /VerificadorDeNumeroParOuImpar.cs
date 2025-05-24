
using System;

class VerificadorDeNumeroParOuImpar {
    static void Main() {
        Console.Write("Digite um número inteiro: ");
        int numero = int.Parse(Console.ReadLine());
        string resultado = numero % 2 == 0 ? "par" : "ímpar";
        Console.WriteLine($"O número {numero} é {resultado}.");
    }
}
