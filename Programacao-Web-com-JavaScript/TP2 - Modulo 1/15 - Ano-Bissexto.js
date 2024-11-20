let ano = parseInt(prompt("Escreva o ano: "));

if ((ano % 4 == 0) &&
  (ano % 100 != 0) ||
  (ano % 400 == 0)) {
  console.log("O ano é bissexto!");
} else {
  console.log("O ano não é bissexto!");
}
