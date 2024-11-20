let escolha = prompt("pedra, papel ou tesoura?").toLowerCase();

let regra = ["pedra", "papel", "tesoura"];

let escolhadaregra = regra[Math.floor(Math.random() * 3)];
 alert("O programa escolheu: " + escolhadaregra);

if (
  (escolhadaregra === "pedra" && escolha === "tesoura") ||
  (escolhadaregra === "papel" && escolha === "pedra") ||
  (escolhadaregra === "tesoura" && escolha === "papel")
) {
  alert("Você perdeu!");
} else if (
  (escolha === "pedra" && escolhadaregra === "tesoura") ||
  (escolha === "papel" && escolhadaregra === "pedra") ||
  (escolha === "tesoura" && escolhadaregra === "papel")
) {
  alert("Você ganhou!");
} else {
  alert("Você empatou!");
}

  