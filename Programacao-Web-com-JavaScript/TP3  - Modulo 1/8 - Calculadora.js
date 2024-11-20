let numero1 = parseFloat(prompt("Insira o primeiro número:"));
let numero2 = parseFloat(prompt("Insira o segundo número:"));
let operacao = prompt("Insira a operação desejada (+ para soma, - para subtração, * para multiplicação, / para divisão):");


let resultado;
switch (operacao) {
    case '+':
        resultado = numero1 + numero2;
        break;
    case '-':
        resultado = numero1 - numero2;
        break;
    case '*':
        resultado = numero1 * numero2;
        break;
    case '/':
        if (numero2 === 0) {
            resultado = "Erro: divisão por zero!";
        } else {
            resultado = numero1 / numero2;
        }
        break;
    default:
        resultado = "Operação inválida.";
}

console.log("O resultado da operação é: " + resultado);
