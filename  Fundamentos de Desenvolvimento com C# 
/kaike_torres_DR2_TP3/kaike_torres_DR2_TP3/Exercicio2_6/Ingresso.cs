using System;

class Ingresso
{
    public string NomeDoShow;
    public double Preco;
    public int QuantidadeDisponivel;

    public Ingresso(string nomeDoShow, double preco, int quantidadeDisponivel)
    {
        NomeDoShow = nomeDoShow;
        Preco = preco;
        QuantidadeDisponivel = quantidadeDisponivel;
    }

    public void AlterarPreco(double novoPreco)
    {
        Preco = novoPreco;
    }

    public void AlterarQuantidade(int novaQuantidade)
    {
        QuantidadeDisponivel = novaQuantidade;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Show: {NomeDoShow}, Preço: {Preco}, Disponível: {QuantidadeDisponivel}");
    }
}
