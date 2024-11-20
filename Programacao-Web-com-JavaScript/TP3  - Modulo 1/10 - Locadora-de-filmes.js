let preco = 10;
let dia = 2;
let categ = "lançamento"

let  valor = 0;

if (categ == "lançamento"){
  preco *= 1.15;
}

switch(dia){
    
  case 2:
  case 3:
  case 5:
    valor = preco * 0.9;
    break

  case 1:
  case 4:
  case 6:
  case 7:
    valor = preco
    break

  default:console.log("Dia invalido")
}

alert(`Valor da locação $${valor.toFixed()}`)