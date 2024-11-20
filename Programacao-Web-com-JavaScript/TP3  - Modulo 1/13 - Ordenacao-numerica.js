
let X = parseInt(prompt("Digite o valor de X (um número inteiro e positivo de 1 a 3):"));
let A = parseFloat(prompt("Digite o valor de A:"));
let B = parseFloat(prompt("Digite o valor de B:"));
let C = parseFloat(prompt("Digite o valor de C:"));


if (X === 1) {
    let valoresOrdenados = [A, B, C].sort((a, b) => a - b);
    console.log("Valores em ordem crescente:", valoresOrdenados);
} else if (X === 2) {
    let valoresOrdenados = [A, B, C].sort((a, b) => b - a);
    console.log("Valores em ordem decrescente:", valoresOrdenados);
} else if (X === 3) {
    let maior = Math.max(A, B, C);
    let menor = Math.min(A, B, C);
    let medio = A + B + C - maior - menor;
    console.log("Valores com o maior entre os outros dois:", menor, maior, medio);
} else {
    console.log("Valor de X inválido. Por favor, insira um número inteiro e positivo de 1 a 3.");
}