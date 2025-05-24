using System;

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, int quantidade, decimal preco)
    {
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }
}