package org.example.Teste;

import org.example.domain.Circulo;
import org.example.domain.Esfera;

public class Figuras {

    public static void main(String[] args) {

        Circulo circulo = new Circulo(3.0);
        Esfera esfera = new Esfera(5.0);

        System.out.printf("Area Circulo: %.2f\nVolume Esfera: %.2f",circulo.calcularArea(), esfera.calcularVolume());

    }

}
