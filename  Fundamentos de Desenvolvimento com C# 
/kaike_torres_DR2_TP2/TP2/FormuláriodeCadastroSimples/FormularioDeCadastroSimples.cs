
using System;

class FormularioDeCadastroSimples {
    static void Main() {
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();
        Console.Write("Digite sua idade: ");
        int idade = int.Parse(Console.ReadLine());
        Console.Write("Digite seu telefone: ");
        string telefone = Console.ReadLine();
        Console.Write("Digite seu e-mail: ");
        string email = Console.ReadLine();
        Console.WriteLine($"Nome: {nome}Idade: {idade}Telefone: {telefone} E-mail: {email}");
    }
}
