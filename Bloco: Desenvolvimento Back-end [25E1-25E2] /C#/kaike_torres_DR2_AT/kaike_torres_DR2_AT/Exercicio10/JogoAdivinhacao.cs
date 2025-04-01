using System;

class JogoAdivinhacao
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);  // Gera um número aleatório entre 1 e 50
        int tentativas = 5;
        bool acertou = false;

        Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
        Console.WriteLine("Você precisa adivinhar um número entre 1 e 50.");
        Console.WriteLine($"Você tem {tentativas} tentativas.");

        while (tentativas > 0 && !acertou)
        {
            Console.Write($"Digite um número (tentativas restantes: {tentativas}): ");
            
            try
            {
                int palpite = int.Parse(Console.ReadLine());

                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("Erro: O número deve estar entre 1 e 50. Tente novamente.");
                }
                else
                {
                    if (palpite == numeroSecreto)
                    {
                        acertou = true;
                        Console.WriteLine("Parabéns! Você acertou o número!");
                    }
                    else if (palpite < numeroSecreto)
                    {
                        Console.WriteLine("O número secreto é maior.");
                    }
                    else
                    {
                        Console.WriteLine("O número secreto é menor.");
                    }
                    tentativas--;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Você deve digitar um número válido.");
            }
        }

        if (!acertou)
        {
            Console.WriteLine($"Você não conseguiu adivinhar o número. O número secreto era {numeroSecreto}.");
        }
    }
}