package org.example.domain;

public class Conta {

    private String titular;
    private int numero;
    private String agencia;
    private double saldo;
    private String dataAbertura;

    public Conta(String titular, int numero, String agencia, double saldo, String dataAbertura) {
        this.titular = titular;
        this.numero = numero;
        this.agencia = agencia;
        this.saldo = saldo;
        this.dataAbertura = dataAbertura;
    }

    public void print(){
        System.out.printf(" Titular: %s\n Numero: %d\n Agencia: %s\n Saldo: %f\n Data da abertura: %s\n Rendimento: %.2f\n", titular, numero, agencia, saldo, dataAbertura,calculaRendimento());
        System.out.println("-----------------------------------------------");
    }



    public void saca(double valor){
        saldo -= valor;
    }

    public void deposita(double valor){
        saldo += valor;
    }

    public double calculaRendimento(){
        return saldo * 0.1;
    }

}
