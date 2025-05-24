package org.example.Parte3;

import java.util.Scanner;

public class SequênciaNuméricaPersonalizada {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Digite o valor inicial: ");
        int valorInicial = scanner.nextInt();

        System.out.print("Digite o incremento: ");
        int incremento = scanner.nextInt();

        int i = valorInicial;
        while (i <= 100) {
            System.out.print(i);
            if (i + incremento <= 100) {
                System.out.print(", ");
            }
            i += incremento;
        }
    }
}
