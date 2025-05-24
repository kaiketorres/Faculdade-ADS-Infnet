using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Digite seu nome completo: ");
        string nome = Console.ReadLine();

       
        string nomeCifrado = CifrarNome(nome);


        Console.WriteLine($"Nome cifrado: {nomeCifrado}");
    }

    static string CifrarNome(string nome)
    {
   
        char[] nomeCifrado = new char[nome.Length];

     
        for (int i = 0; i < nome.Length; i++)
        {
            char c = nome[i];

         
            if (char.IsLetter(c))
            {
                bool isUpper = char.IsUpper(c);

                char cLower = char.ToLower(c);

                cLower = (char)((cLower - 'a' + 2) % 26 + 'a');

                if (isUpper)
                {
                    cLower = char.ToUpper(cLower);
                }

                nomeCifrado[i] = cLower;
            }
            else
            {
                nomeCifrado[i] = c;
            }
        }

        return new string(nomeCifrado);
    }
}