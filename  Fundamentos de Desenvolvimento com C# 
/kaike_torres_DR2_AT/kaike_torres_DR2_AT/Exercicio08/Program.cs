class Program
{
    static void Main()
    {
        Funcionario funcionario = new Funcionario("Carlos Silva", "Analista", 3000);
        Gerente gerente = new Gerente("Ana Souza", 5000);

        Console.WriteLine($"Funcionário: {funcionario.Nome}, Cargo: {funcionario.Cargo}, Salário: R${funcionario.CalcularSalario():F2}");
        Console.WriteLine($"Gerente: {gerente.Nome}, Cargo: {gerente.Cargo}, Salário: R${gerente.CalcularSalario():F2}");
    }
}