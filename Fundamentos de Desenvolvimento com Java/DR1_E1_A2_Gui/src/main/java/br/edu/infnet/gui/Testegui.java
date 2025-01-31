package main.java.br.edu.infnet.gui;

import javax.swing.*;

public class Testegui {

    public static void main(String[] args) {
        System.out.println("Antes da Mensagem");
        JOptionPane.showMessageDialog(
                null,
                "Mensagem da Aplicação",  // Texto da mensagem
                "Título",                  // Título da janela
                JOptionPane.INFORMATION_MESSAGE  // Tipo da mensagem
        );
    }
}
