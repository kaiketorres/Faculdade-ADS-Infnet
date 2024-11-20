let quilos = parseFloat(window.prompt("Digite a quantidade de quilos de peixe: "))

if(quilos > 50){ 
  quilos -= 50
  let multa = quilos * 4
  window.alert(`Você excedeu o limite de quilos em ${quilos}kg, portanto deve pagar uma multa de R$${multa} reais`)
} else{
  window.alert("Você não excedeu o limite de quilos")
}