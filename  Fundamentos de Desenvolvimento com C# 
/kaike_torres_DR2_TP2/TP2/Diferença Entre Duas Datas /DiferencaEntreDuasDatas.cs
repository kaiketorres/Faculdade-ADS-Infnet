
using System;

class DiferencaEntreDuasDatas {
    static void Main() {
        Console.Write("Digite a primeira data (dd/mm/yyyy): ");
        DateTime data1 = DateTime.Parse(Console.ReadLine());
        Console.Write("Digite a segunda data (dd/mm/yyyy): ");
        DateTime data2 = DateTime.Parse(Console.ReadLine());
        TimeSpan diferenca = data2 - data1;
        int anos = diferenca.Days / 365;
        int meses = (diferenca.Days % 365) / 30;
        int dias = (diferenca.Days % 365) % 30;
        Console.WriteLine($"A diferença entre as duas datas é de {anos} anos, {meses} meses e {dias} dias.");
    }
}
