package org.example.Parte1;

import java.util.Scanner;

public class CadastroUsuario {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);


        System.out.print("Digite seu nome completo: ");
        String nomeUsuario = scanner.nextLine();


        System.out.print("Digite sua idade: ");
        int idade = scanner.nextInt();
        scanner.nextLine();


        System.out.print("Digite o nome de sua mãe: ");
        String nomeMae = scanner.nextLine();

        System.out.print("Digite o nome de seu pai: ");
        String nomePai = scanner.nextLine();

        System.out.println("\nCadastro Completo:");
        System.out.println("Nome completo: " + nomeUsuario);
        System.out.println("Idade: " + idade);
        System.out.println("Nome da mãe: " + nomeMae);
        System.out.println("Nome do pai: " + nomePai);


        int tamanhoNomeUsuario = nomeUsuario.length();
        int tamanhoNomeMae = nomeMae.length();
        int tamanhoNomePai = nomePai.length();

        if (tamanhoNomeUsuario > tamanhoNomeMae && tamanhoNomeUsuario > tamanhoNomePai) {
            System.out.println("O nome do usuário é o mais longo.");
        } else if (tamanhoNomeMae > tamanhoNomeUsuario && tamanhoNomeMae > tamanhoNomePai) {
            System.out.println("O nome da mãe é o mais longo.");
        } else if (tamanhoNomePai > tamanhoNomeUsuario && tamanhoNomePai > tamanhoNomeMae) {
            System.out.println("O nome do pai é o mais longo.");
        } else {
            System.out.println("Há dois ou mais nomes com o mesmo comprimento máximo.");
        }

        scanner.close();
    }
}
