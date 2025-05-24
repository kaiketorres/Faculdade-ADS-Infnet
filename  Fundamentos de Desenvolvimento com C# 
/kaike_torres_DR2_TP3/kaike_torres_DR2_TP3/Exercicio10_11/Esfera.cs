using System;

class Esfera
{
    public double Raio;

    public Esfera(double raio)
    {
        Raio = raio;
    }

    public double CalcularVolume()
    {
        return (4.0 / 3.0) * Math.PI * (Raio * Raio * Raio);
    }
}
