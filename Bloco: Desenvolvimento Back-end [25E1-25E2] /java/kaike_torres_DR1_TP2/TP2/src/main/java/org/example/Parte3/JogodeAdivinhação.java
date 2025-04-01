package org.example.Parte3;

import java.util.Random;
import java.util.Scanner;

public class JogodeAdivinhação {
    public static void main(String[] args) {
        Random random = new Random();
        Scanner scanner = new Scanner(System.in);
        int numeroSecreto = random.nextInt(100) + 1;
        int palpite;

        do {
            System.out.print("Adivinhe o número (1 a 100): ");
            palpite = scanner.nextInt();

            if (palpite < numeroSecreto) {
                System.out.println("O número é maior.");
            } else if (palpite > numeroSecreto) {
                System.out.println("O número é menor.");
            }
        } while (palpite != numeroSecreto);

        System.out.println("Parabéns! Você acertou.");
    }
}
