package org.example.Teste;


import org.example.domain.Conta;

public class Contas {
    public static void main(String[] args) {

        Conta conta = new Conta("kaike",34534643,"nubank", 300,"16/03/2025");

        conta.print();

        conta.saca(50);
        conta.deposita(10);
        conta.calculaRendimento();

        conta.print();
    }
}
