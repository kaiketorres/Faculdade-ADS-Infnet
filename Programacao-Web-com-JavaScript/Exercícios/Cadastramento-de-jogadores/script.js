const atdeJogadores = 1;
const jogadores = [];


for(let i= 0; i < atdeJogadores; i++){
    let nome = window.prompt(`Digite o nome do jogador ${i + 1}:`)

    let posicao = escolhaPosiçao();
  
    let camisa = parseInt(window.prompt(`Digite a camisa do jogador ${nome}:`));
    
    let anoNascimento= parseInt(window.prompt(`Digite o ano de nacimento do jogador ${nome}:`));
    
    let salario = parseFloat(window.prompt(`Digite o salario do jogador ${nome}:`));

    jogadores.push(
        {
            nome: nome, 
            posicao: posicao,
            camisa: camisa,
            anoNascimento: anoNascimento,
            salario: salario
        }
        
    )


        
}


function escolhaPosiçao(){

    let dominio = ["goleiro", "zagueiro", "lateral", "meio", "atacante"] 

    let posicao = parseInt(window.prompt("Escolha uma posição de jogador: \n 1 - Goleiro \n 2 - Zagueiro \n 3 - Lateral  \n 4 - Meio \n 5 -Atacante "))
    

    return dominio[posicao-1]
}

impressao(jogadores)

function impressao(osJogadores){

    osJogadores.forEach((func, index) =>{

        let salraioLiquido = calcularSalarioComBonus(func.salario, func.anoNascimento);

        alert((index + 1) + " nome: " + func.nome + " - posicao: " + func.posicao + " - Salario: " + func.salario + " - Salario Liquido: " + salraioLiquido);
    })
        
    }

    function calcularIdade(oAno){
        
        const anoAtual = new Date().getFullYear();
        
        return anoAtual - oAno;
    }

    function calculoBonusPorIdade(aIdade){      
        
        if(aIdade <= 20){
            return 1;
        }else if(aIdade > 40){
            return 0.5;
        }else{
            return 2;
        }
    }


    function calculoBonusPorPosicao(){
        return 0;
    }

    
    function calcularSalarioComBonus(oSalario,oAnoNascimento){

        let idade = calcularIdade(oAnoNascimento)

        let valorBonusPorIdade = oSalario * calculoBonusPorIdade(idade);

        let valorBonusPorPosicao = calculoBonusPorPosicao();

        
        return oSalario + valorBonusPorPosicao + valorBonusPorIdade 
    }


    












