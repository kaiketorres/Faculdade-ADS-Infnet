
using System;

class jogo_de_adivinhacao {
    static void Main() {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int palpite = 0;
        Console.WriteLine("Tente adivinhar o número secreto entre 1 e 100!");
        while (palpite != numeroSecreto) {
            Console.Write("Digite seu palpite: ");
            palpite = int.Parse(Console.ReadLine());
            if (palpite < numeroSecreto) Console.WriteLine("Maior!");
            else if (palpite > numeroSecreto) Console.WriteLine("Menor!");
        }
        Console.WriteLine("Parabéns! Você acertou o número secreto.");
    }
}
