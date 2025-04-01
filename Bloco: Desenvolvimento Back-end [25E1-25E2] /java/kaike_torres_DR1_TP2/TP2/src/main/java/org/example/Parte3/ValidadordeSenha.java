package org.example.Parte3;

import java.util.Scanner;

public class ValidadordeSenha {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String senhaCorreta = "senha123";
        String senha;

        do {
            System.out.print("Digite a senha: ");
            senha = scanner.nextLine();
        } while (!senha.equals(senhaCorreta));

        System.out.println("Senha correta! Acesso concedido.");
    }
}
