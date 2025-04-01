using System;

class ContaBancaria
{
    public string Titular { get; set; }
    private decimal Saldo { get; set; }

    public ContaBancaria(string titular)
    {
        Titular = titular;
        Saldo = 0;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
        }
        else
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
        }
    }

    public void Sacar(decimal valor)
    {
        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
        }
        else
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
        }
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {Saldo:F2}");
    }
}