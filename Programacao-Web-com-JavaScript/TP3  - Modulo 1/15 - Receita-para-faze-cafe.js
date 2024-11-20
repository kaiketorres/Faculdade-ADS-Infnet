let passo = parseInt(prompt("Digite o número do passo desejado (entre 1 e 10):"));

let instrucoes = '';


switch (passo) {
    case 1:
        instrucoes = "Passo 1: Escolha os grãos de café. \n";
    case 2:
        instrucoes += "Passo 2: Coloque os grãos na máquina de torrefação. \n";
    case 3:
        instrucoes += "Passo 3: Aguarde até que os grãos estejam torrados. \n";
    case 4:
        instrucoes += "Passo 4: Remova os grãos torrados da máquina. \n";
    case 5:
        instrucoes += "Passo 5: Moa os grãos torrados. \n"; 
    case 6:
        instrucoes += "Passo 6: Prepare o filtro na máquina de café. \n";
    case 7:
        instrucoes += "Passo 7: Coloque o café moído no filtro. \n";
    case 8:
        instrucoes += "Passo 8: Adicione água à máquina de café. \n";
    case 9:
        instrucoes += "Passo 9: Ligue a máquina e aguarde até que o café seja feito. \n";
    case 10:
        instrucoes += "Passo 10: Sirva o café e aproveite! \n";
        break;
    default:
        instrucoes += "Passo inválido. Certifique-se de digitar um número entre 1 e 10. ";
}

alert(instrucoes);
