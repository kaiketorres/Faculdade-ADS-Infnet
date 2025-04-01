using System;

class TestaFormas
{
    static void Main()
    {
        Circulo circulo = new Circulo(5.0);
        Console.WriteLine($"Área do círculo: {circulo.CalcularArea():F2}");

        Esfera esfera = new Esfera(5.0);
        Console.WriteLine($"Volume da esfera: {esfera.CalcularVolume():F2}");
    }
}
