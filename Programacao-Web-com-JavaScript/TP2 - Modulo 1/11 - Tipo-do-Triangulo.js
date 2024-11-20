let ladoA = Number(prompt( "Informe o lado A do triângulo: "));
let ladoB = Number(prompt( "Informe o lado B do triângulo: "));
let ladoC = Number(prompt( "Informe o lado C do triângulo: "));


if(ladoA == ladoB && ladoB == ladoC){
  alert("Equilátero");
} else if (ladoA == ladoB || ladoB == ladoC || ladoA == ladoC){
  alert("Isósceles");
} else {
  alert("Escaleno");  
}