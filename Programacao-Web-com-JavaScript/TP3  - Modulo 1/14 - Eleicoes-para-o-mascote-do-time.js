let votosRoboRat = parseFloat(prompt("Digite a quantidade de votos para RoboRat:"));
let votosSuperKeyboard = parseFloat(prompt("Digite a quantidade de votos para SuperKeyboard:"));
let votosInvalidos = parseFloat(prompt("Digite a quantidade de votos inválidos:"));

let totalVotos = votosRoboRat + votosSuperKeyboard + votosInvalidos;

let percentualRoboRat = (votosRoboRat / totalVotos) * 100;
let percentualSuperKeyboard = (votosSuperKeyboard / totalVotos) * 100;
let percentualInvalidos = (votosInvalidos / totalVotos) * 100;

let percentualRoboRatValidos = (votosRoboRat / (totalVotos - votosInvalidos)) * 100;
let percentualSuperKeyboardValidos = (votosSuperKeyboard / (totalVotos - votosInvalidos)) * 100;

alert("A porcentagem de votos de RoboRat é de: " + percentualRoboRat.toFixed(2) + "% \nA porcentagem de votos de SuperKeyboard é de: " + percentualSuperKeyboard.toFixed(2) + "% \nA porcentagem de votos inválidos é de: " + percentualInvalidos.toFixed(2) + "%");

alert("A Porcentagem de votos válidos de RoboRat: " + percentualRoboRatValidos.toFixed(2) + "% \nA porcentagem de votos válidos de SuperKeyboard: " + percentualSuperKeyboardValidos.toFixed(2) + "%");

if(votosRoboRat > votosSuperKeyboard){
  alert("RoboRat ganhou a eleição!");
} else {
  alert("SuperKeyboard ganhou a eleição!");
}