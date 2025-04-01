package org.example.Parte1;

import java.util.Scanner;

public class ConversorDeMoedas {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        final double TAXA_DOLAR = 5.25;
        final double TAXA_EURO = 5.80;
        final double TAXA_LIBRA = 6.70;

        System.out.print("Digite o valor em reais: R$ ");
        double valorReais = scanner.nextDouble();

        System.out.println("Escolha a moeda de destino: ");
        System.out.println("1 - Dólar");
        System.out.println("2 - Euro");
        System.out.println("3 - Libra");
        System.out.print("Digite o número correspondente à moeda escolhida: ");
        int opcao = scanner.nextInt();

        double valorConvertido = 0.0;

        switch (opcao) {
            case 1:
                valorConvertido = valorReais / TAXA_DOLAR;
                System.out.printf("Valor convertido para Dólares: $ %.2f\n", valorConvertido);
                break;
            case 2:
                valorConvertido = valorReais / TAXA_EURO;
                System.out.printf("Valor convertido para Euros: € %.2f\n", valorConvertido);
                break;
            case 3:
                valorConvertido = valorReais / TAXA_LIBRA;
                System.out.printf("Valor convertido para Libras: £ %.2f\n", valorConvertido);
                break;
            default:
                System.out.println("Opção inválida. Escolha 1, 2 ou 3.");
                break;
        }

        scanner.close();
    }
}
