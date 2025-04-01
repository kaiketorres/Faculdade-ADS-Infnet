using System;

class Matricula
{
    public string NomeDoAluno;
    public string Curso;
    public int NumeroMatricula;
    public string Situacao;
    public string DataInicial;

    public Matricula(string nomeDoAluno, string curso, int numeroMatricula, string dataInicial)
    {
        NomeDoAluno = nomeDoAluno;
        Curso = curso;
        NumeroMatricula = numeroMatricula;
        Situacao = "Ativa";
        DataInicial = dataInicial;
    }

    public void Trancar()
    {
        Situacao = "Trancada";
    }

    public void Reativar()
    {
        Situacao = "Ativa";
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Aluno: {NomeDoAluno}, Curso: {Curso}, Matrícula: {NumeroMatricula}, Situação: {Situacao}, Início: {DataInicial}");
    }
}
