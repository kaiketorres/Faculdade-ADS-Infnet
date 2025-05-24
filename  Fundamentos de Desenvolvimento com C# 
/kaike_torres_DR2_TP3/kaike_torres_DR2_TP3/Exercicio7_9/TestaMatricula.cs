using System;

class TestaMatricula
{
    static void Main()
    {
        Matricula matricula = new Matricula("Kaike Torres", "ADS", 12345, "01/03/2025");
        matricula.ExibirInformacoes();
        matricula.Trancar();
        matricula.ExibirInformacoes();
        matricula.Reativar();
        matricula.ExibirInformacoes();
    }
}
