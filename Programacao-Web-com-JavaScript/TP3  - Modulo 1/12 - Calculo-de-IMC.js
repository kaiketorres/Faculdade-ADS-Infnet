let altura = prompt("Diga sua altura em metros: ");
let peso = prompt("Diga seu peso em kg: ");

let imc = peso / (altura * altura);

if(imc < 16){
  alert(imc.toFixed(2) + " Baixo peso (grau I)");
} else {
  if(imc < 16.99){
    alert(imc.toFixed(2) + " Baixo peso (grau II)");
  } else {
    if(imc < 18.49){
      alert(imc.toFixed(2) + " Baixo peso (grau III)");
    } else {
      if(imc < 25){
        alert(imc.toFixed(2) + " Peso ideal");
      } else {
        if(imc < 29.99){
          alert(imc.toFixed(2) + " Sobrepeso");
        } else {
          if(imc < 35){
            alert(imc.toFixed(2) + " Obesidade (grau I)");
          } else {
            if(imc < 39.99){
              alert(imc.toFixed(2) + " Obesidade (grau II)");
            } else {
              alert(imc.toFixed(2) + " Obesidade (grau III)");
            }
          }
        }
      }
    }
  }
}  