package org.example.domain;

public class Usuario {

    private String nome;
    private int idade;
    private char sexo;

    public Usuario(String nome, int idade, char sexo) {
        this.nome = nome;
        this.idade = idade;
        this.sexo = sexo;
    }

    public void print(){
        System.out.printf("Nome do Usuario: %s Idade: %d Sexo: %s ", nome, idade, sexo);
    }
}
