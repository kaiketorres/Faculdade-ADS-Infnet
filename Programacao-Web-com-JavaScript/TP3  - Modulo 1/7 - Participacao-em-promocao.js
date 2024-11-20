let sexo = window.prompt("Qual e seu sexo?")

let idade = parseFloat(window.prompt("Quantos anos voce tem?"))

let viagem = parseInt(window.prompt("Quatas vezes você ja viajou?"))

if( sexo == "homem" && idade >= 40 && viagem == 0 || sexo == "homem" && idade >= 40 && viagem == 2 || sexo == "homem" && idade >= 35 && viagem == 1){
    window.alert("Você tem as condiçoes para participar da promoção")
}  
else if (sexo == "mulher" && idade >= 35 && viagem == 0|| sexo == "mulher" && idade >= 35 && viagem == 3 || sexo == "mulher" && idade >= 30 && viagem == 2 ){
    window.alert("Você tem as condiçoes para participar da promoção")
} else{
    window.alert("Você não tem as condiçoes para participar da promoção")
}









