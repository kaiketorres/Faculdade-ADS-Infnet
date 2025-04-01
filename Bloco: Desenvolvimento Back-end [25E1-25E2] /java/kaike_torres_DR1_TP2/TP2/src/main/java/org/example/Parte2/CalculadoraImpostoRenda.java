package org.example.Parte2;

import java.util.Scanner;

public class CalculadoraImpostoRenda {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        System.out.print("Digite o seu salário bruto anual: R$ ");
        double salarioBruto = scanner.nextDouble();

        double imposto = 0;

        if (salarioBruto <= 22847.76) {
            imposto = 0;
        } else if (salarioBruto <= 33919.80) {
            imposto = (salarioBruto - 22847.76) * 0.075;
        } else if (salarioBruto <= 45012.60) {
            imposto = (salarioBruto - 33919.80) * 0.15 + 829.07;
        } else if (salarioBruto <= 55976.16) {
            imposto = (salarioBruto - 45012.60) * 0.225 + 1257.87; // 22.5% de imposto
        } else {
            imposto = (salarioBruto - 55976.16) * 0.275 + 1903.98; // 27.5% de imposto
        }

        double salarioLiquido = salarioBruto - imposto;

        System.out.printf("Imposto a pagar: R$ %.2f\n", imposto);
        System.out.printf("Salário líquido: R$ %.2f\n", salarioLiquido);

        scanner.close();
    }
}
