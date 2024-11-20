const tipo = "Industrial"
const consumo = 50;

let valor = 0;

switch(tipo){
  case "Residencial":
    valor = 5 + (0.05 *consumo);
    break

  case "Comercial":
    valor = 500;
    if(consumo > 80){
      valor = valor + (0.25 * (consumo - 80))
    }
    break
    
    case "Industrial":
    valor = 800;
    if(consumo > 100){
      valor = valor + (0.04 * (consumo - 100))
    }

    break

  default:
    console.log("Tipo inválido")
}