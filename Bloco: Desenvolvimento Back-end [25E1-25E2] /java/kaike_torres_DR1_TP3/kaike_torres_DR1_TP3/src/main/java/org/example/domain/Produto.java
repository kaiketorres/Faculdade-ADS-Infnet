package org.example.domain;

public class Produto {

    private String nome = "Café";
    private double preco = 50;
    private int quantEstoque =  2;

    public Produto(String nome, double preco, int quantEstoque) {
        this.nome = nome;
        this.preco = preco;
        this.quantEstoque = quantEstoque;
    }

    public void  alterarPreco(double preco){
        this.preco = preco;
    }

    public void  alterarQuantidade(int quantEstoque){
        this.quantEstoque = quantEstoque;
    }

    public void exibirInformacoes(){
        System.out.printf("Nome: %s Preço: %.2f Quantidade: %d\n", nome, preco, quantEstoque);
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public double getPreco() {
        return preco;
    }

    public void setPreco(double preco) {
        this.preco = preco;
    }

    public int getQuantEstoque() {
        return quantEstoque;
    }

    public void setQuantEstoque(int quantEstoque) {
        this.quantEstoque = quantEstoque;
    }
}
