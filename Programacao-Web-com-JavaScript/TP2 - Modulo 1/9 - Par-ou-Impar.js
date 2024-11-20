let escolher = window.prompt("Escolha par ou impar")

let numeroAletorio = parseInt(Math.random() * 100)

const meunumeroPar = numeroAletorio % 2 === 0

window.alert(`Esse foi o numero sorteado ${numeroAletorio}`)

if (escolher === "par" && meunumeroPar || escolher === "impar" && !meunumeroPar){
  alert("ganhou");
} else {
  alert("perdeu")
}