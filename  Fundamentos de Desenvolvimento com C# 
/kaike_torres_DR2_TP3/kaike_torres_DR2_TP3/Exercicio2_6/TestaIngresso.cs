using System;

class TestaIngresso
{
    static void Main()
    {
        Ingresso ingresso = new Ingresso("Rock Festival", 150.0, 100);
        ingresso.ExibirInformacoes();
        ingresso.AlterarPreco(180.0);
        ingresso.AlterarQuantidade(80);
        ingresso.ExibirInformacoes();
    }
}
