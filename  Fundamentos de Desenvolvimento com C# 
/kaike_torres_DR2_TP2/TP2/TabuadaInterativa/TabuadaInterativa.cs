
using System;

class TabuadaInterativa {
    static void Main() {
        Console.Write("Digite um número para ver sua tabuada: ");
        int numero = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 10; i++) {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }
}
