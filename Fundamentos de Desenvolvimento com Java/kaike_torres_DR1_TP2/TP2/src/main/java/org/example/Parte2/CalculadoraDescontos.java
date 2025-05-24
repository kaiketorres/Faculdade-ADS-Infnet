package org.example.Parte2;

import java.util.Scanner;

public class CalculadoraDescontos {

    public static void main(String[] args) {


    Scanner scanner = new Scanner(System.in);


        System.out.print("Digite o valor da compra (R$): ");
    double valorCompra = scanner.nextDouble();

    double desconto = 0;
       if (valorCompra > 1000) {
        desconto = 0.10;
    } else if (valorCompra >= 500) {
        desconto = 0.05;
    }

    double valorDesconto = valorCompra * desconto;
    double valorFinal = valorCompra - valorDesconto;

        System.out.printf("Valor original: R$ %.2f\n", valorCompra);
        System.out.printf("Desconto aplicado: R$ %.2f (%.0f%%)\n", valorDesconto, desconto * 100);
        System.out.printf("Valor final: R$ %.2f\n", valorFinal);

        scanner.close();
}
}
