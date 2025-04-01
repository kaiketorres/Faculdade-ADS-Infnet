package org.example.domain;

public class Esfera {

    private double raio;

    public Esfera(double raio) {
        this.raio = raio;
    }


    public double calcularVolume(){
        return (4.0 / 3.0) * Math.PI * Math.pow(raio, 3);
    }

}
