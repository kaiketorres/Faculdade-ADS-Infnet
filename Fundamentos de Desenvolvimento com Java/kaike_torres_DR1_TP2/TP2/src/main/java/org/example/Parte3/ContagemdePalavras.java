package org.example.Parte3;

import java.util.Scanner;

public class ContagemdePalavras {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Digite uma frase: ");
        String frase = scanner.nextLine();

        String[] palavras = frase.split("\\s+");
        System.out.println("Número de palavras: " + palavras.length);
    }
}
