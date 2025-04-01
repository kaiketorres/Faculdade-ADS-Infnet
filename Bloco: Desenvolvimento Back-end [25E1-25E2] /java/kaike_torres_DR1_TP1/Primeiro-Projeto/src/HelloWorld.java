import java.util.Scanner;

public class HelloWorld {
    public static void main(String[] args) {

        System.out.println("Exercício 4: Escrever um Programa Simples em Java");

        System.out.println("Hello, World!");

        System.out.println("///////////////////////////////");

        System.out.println("Exercício 7: Modificar e Re-executar o Programa");

        System.out.println("Nome: kaike");

        System.out.println("Idade: 21");

        System.out.println("Altura: 1.70");

        System.out.println("///////////////////////////////");


        System.out.println("//Exercício 8: Usar Variáveis e Tipos de Dados");

        String jogo = "watch dogs";
        System.out.println("Nome do jogo: " + jogo);

        int anoLancamento = 2014;
        System.out.println("Ano do lançamento: " + anoLancamento);

        double preco = 150.99;
        System.out.println("Preço:" + preco);

        System.out.println("///////////////////////////////");

        System.out.println("Exercício 9: Ler Entrada do Usuário");

        Scanner input = new Scanner(System.in);

        System.out.print("Digite seu nome:");
        String nome = input.nextLine();

        System.out.print("Digite sua idade:");
        int idade = input.nextInt();

        System.out.println("Nome" + nome + " Idade: " + idade);


    }
}