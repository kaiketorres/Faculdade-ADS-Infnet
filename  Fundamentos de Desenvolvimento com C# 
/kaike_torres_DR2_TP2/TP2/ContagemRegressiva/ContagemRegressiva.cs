
using System;

class ContagemRegressiva {
    static void Main() {
        Console.Write("Digite um número para contagem regressiva: ");
        int numero = int.Parse(Console.ReadLine());
        for (int i = numero; i >= 0; i--) {
            Console.Write(i + (i == 0 ? "." : ", "));
        }
    }
}
