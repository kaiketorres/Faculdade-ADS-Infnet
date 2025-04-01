using System;

class Carro
{
    public string Marca;
    public int Ano;

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Carro: {Marca}, Ano: {Ano}");
    }
}

class Program
{
    static void Main()
    {
        Carro meuCarro = new Carro();
        meuCarro.Marca = "Toyota";
        meuCarro.Ano = 2022;
        meuCarro.ExibirInformacoes();
    }
}