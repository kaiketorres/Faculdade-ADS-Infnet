
using System;

class ConversorDeTemperatura {
    static void Main() {
        Console.Write("Digite a temperatura em Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        double fahrenheit = celsius * 9 / 5 + 32;
        double kelvin = celsius + 273.15;
        Console.WriteLine($"Temperatura em Fahrenheit: {fahrenheit:F2} Temperatura em Kelvin: {kelvin:F2}");
    }
}
