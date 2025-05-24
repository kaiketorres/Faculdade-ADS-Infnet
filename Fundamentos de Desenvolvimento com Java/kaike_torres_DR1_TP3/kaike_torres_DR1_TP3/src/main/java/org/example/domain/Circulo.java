package org.example.domain;

public class Circulo {

    private double raio;

    public Circulo(double raio) {
        this.raio = raio;
    }

    public double calcularArea(){
        return Math.PI * Math.pow(raio, 2);
    }
}
