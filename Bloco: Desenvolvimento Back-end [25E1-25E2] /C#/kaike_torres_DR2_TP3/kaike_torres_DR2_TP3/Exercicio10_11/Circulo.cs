using System;

class Circulo
{
    public double Raio;

    public Circulo(double raio)
    {
        Raio = raio;
    }

    public double CalcularArea()
    {
        return Math.PI * (Raio * Raio);
    }
}
