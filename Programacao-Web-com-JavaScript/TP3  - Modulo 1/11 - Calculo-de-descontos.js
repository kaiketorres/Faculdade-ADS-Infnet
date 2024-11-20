let situacao = prompt("Digite seu estado Gestante(A) Aposentado(B) Pensionista(C)");
let valor = "";
let mensagem = "";

switch(situacao){
  case "A":
    valor = parseInt(prompt("Digite o valor da compra."));
      if (valor >= 80){
        mensagem = "Desconto de 20% aplicado " + (valor - (valor * 0.2));
      } else {
        mensagem = "Desconto de 15% aplicado " + (valor - (valor * 0.15));
      }
    break;
  case "B":
    valor = parseInt(prompt("Digite o valor da compra."));
      if (valor >= 80){
        mensagem = "Desconto de 15% aplicado " + (valor - (valor * 0.15));
      } else {
        mensagem = "Desconto de 10% aplicado " + (valor - (valor * 0.1));
      }
    break;
  case "C":
    valor = parseInt(prompt("Digite o valor da compra."));
      if (valor >= 80){
        mensagem = "Desconto de 10% aplicado " + (valor - (valor * 0.1));
      } else {
        mensagem = "Desconto de 5% aplicado " + (valor - (valor * 0.05));
      }      
    break;
  default:
    mensagem = "Erro! Digite algo válido.";
}
alert(mensagem);





