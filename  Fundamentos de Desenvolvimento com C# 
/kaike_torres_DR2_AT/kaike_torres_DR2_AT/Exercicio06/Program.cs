class Program
{
    static void Main(string[] args)
    {
        Aluno aluno = new Aluno
        {
            Nome = "Kaike Torres da Silva",
            Matricula = "123456",
            Curso = "Análise e Desenvolvimento de Sistemas",
            MediaNotas = 8.5
        };

        aluno.ExibirDados();
        Console.WriteLine($"Status: {aluno.VerificarAprovacao()}");
    }
}