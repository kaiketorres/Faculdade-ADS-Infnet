class Program
{
    static void Main(string[] args)
    {
        // Criação do objeto ContaBancaria
        ContaBancaria conta = new ContaBancaria("João Silva");

        // Realização de transações
        conta.Depositar(500);
        conta.ExibirSaldo();

        conta.Sacar(700);  // Saque com valor maior que o saldo
        conta.Sacar(200);  // Saque válido
        conta.ExibirSaldo();
    }
}