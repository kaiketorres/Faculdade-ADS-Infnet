package org.example.Teste;

import org.example.domain.Produto;

public class Produtos {

    public static void main(String[] args) {

        Produto produto = new Produto("Leite", 30 , 20);

        produto.alterarPreco(40);
        produto.alterarQuantidade(10);
        produto.exibirInformacoes();

        produto.setNome("Banana");
        produto.setPreco(10);
        produto.setQuantEstoque(40);

        System.out.printf("Nome: %s Preço: %.2f Quantidade: %d", produto.getNome(), produto.getPreco(), produto.getQuantEstoque());



    }

}
