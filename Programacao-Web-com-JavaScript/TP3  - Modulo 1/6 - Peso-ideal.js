
function calcularPesoIdeal(altura, sexo) {
    switch (sexo.toLowerCase()) {
        case 'masculino':
            return (72.7 * altura) - 58;
        case 'feminino':
            return (62.1 * altura) - 44.7;
        default:
            return "Sexo inválido. Por favor, insira 'masculino' ou 'feminino'.";
    }
}

let altura = parseFloat(prompt("Insira sua altura em metros:"));
let sexo = prompt("Insira seu sexo (masculino/feminino):");

let pesoIdeal = calcularPesoIdeal(altura, sexo);
if (!isNaN(pesoIdeal)) {
    console.log("Seu peso ideal é: " + pesoIdeal.toFixed(2) + " kg");
} else {
    console.log(pesoIdeal);
}
