
using System;

class ClassificacaoDeNotaEscolar {
    static void Main() {
        Console.Write("Digite a nota (0-10): ");
        double nota = double.Parse(Console.ReadLine());
        string classificacao = nota < 4 ? "Insuficiente" :
                               nota < 7 ? "Regular" :
                               nota < 9 ? "Bom" : "Excelente";
        Console.WriteLine($"A nota {nota} é classificada como: {classificacao}.");
    }
}
