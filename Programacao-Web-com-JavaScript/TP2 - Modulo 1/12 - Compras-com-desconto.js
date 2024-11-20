const valor = parseFloat(prompt("Informa o valor da compra: "));
const pagamento = prompt("Informe a forma de pagamento: dinheiro, débito, crédito, até 3x, acima de 3x. ").toLowerCase();

let valorFinal = 0;
let qtdeParcela = 1;
let sucesso = true;

if(pagamento == "dinheiro"){
  valorFinal = valor * 0.90;
} else if(pagamento == "débito"){
  valorFinal = valor * 0.92; 
} else if(pagamento == "crédito"){
  valorFinal = valor * 0.95;
} else if(pagamento == "até 3x"){
  qtdeParcela = parseInt(prompt("Informe a quantidade de parcelas: "));
  if(qtdeParcela <= 1 || qtdeParcela > 3){
    alert("Ops... qtde de parcelas incorreta!!");
    sucesso = false;
  }
  valorFinal = valor / qtdeParcela;
} else if(pagamento == "acima de 3x"){
  qtdeParcela = parseInt(prompt("Informe a quantidade de parcelas: "));
  if(qtdeParcela <= 3){
    alert("Ops... quantidade de parcelas incorreta!!");
    sucesso = false;
  }
  
  valorFinal = valor * 1.04 / qtdeParcela;
}

if(sucesso){
  alert("Valor final R$" + valorFinal.toFixed(2) + "; Forma de pagamento " + pagamento + "; Parcelamento " + qtdeParcela);
}
//KAIKE RESPONDE O TEAMS CARA//
  



