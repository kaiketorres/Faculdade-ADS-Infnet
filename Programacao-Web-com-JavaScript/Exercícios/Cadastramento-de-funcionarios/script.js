let funcionarios = [];

function incluirFuncionario(){
  const nome = prompt("Digite o nome do funcionário: ");
  const idade = parseInt(prompt("Digite a idade do funcionário: "));
  const cargo = prompt("Digite o cargo do funcionário: ");
  const salarioBruto = parseFloat(prompt("Digite o salário bruto do funcionário: "));
  const experiencia = parseInt(prompt("Digite a experiência do funcionário (1 - 5): "));
  const ativo = true;
  const motivo = "";
  
  funcionarios.push({nome, idade, cargo, salarioBruto, experiencia, ativo, motivo});
  
  alert("O Funcionário cadastrado com sucesso!!!");
}

function exibirTodos(){
  let lista = "";
  for(let i = 0; i < funcionarios.length; i++){
    const func = funcionarios[i];

    if(func.ativo){
      let salarioLiquido = calcularSalarioLiquido(func.salarioBruto, func.experiencia);
      
      lista = lista + "["+func.ativo+"] Funcionário "+(i+1)+": Nome: " + func.nome + "; Salário: " + salarioLiquido + "\n";
    }
  }
  alert("Funcionários: \n\n" + lista);    
}

function exibirIndividual(){
  const indice = parseInt(prompt("Digite o índice do funcionário: "));

  if(indice >= 0 && indice < funcionarios.length){
    const func = funcionarios[indice];

    if(func.ativo){
      let salarioLiquido = calcularSalarioLiquido(func.salarioBruto, func.experiencia);
      
      alert("["+func.ativo+"] Funcionários: \n\n Funcionário "+(indice+1)+": Nome: " + func.nome + "; Salário: " + salarioLiquido + "\n");    
    } else {
      alert("Este funcionário não está ativo: " + func.motivo + "\n");    
    }
  } else {
    alert(indice + " não é um índice válido!!!")
  }
}

function calcularSalarioLiquido(oSalarioBruto, aExperiencia){

  let fatorExperiencia = 1;

  switch (aExperiencia){
    case 1:
      fatorExperiencia = 0.90;
      break;
    case 2:
      fatorExperiencia = 0.95;
      break;
    case 3:
    case 4:
    case 5:
      fatorExperiencia = 1
      break;
  }

  return oSalarioBruto * fatorExperiencia;
}

function excluirFuncionario(){
  const indice = parseInt(prompt("Digite o índice do funcionário: "));

  if(indice >= 0 && indice < funcionarios.length){
    const func = funcionarios[indice];

    func.ativo = false;
    func.motivo = prompt("Digite o motivo da exclusão: ");
  
    alert("O Funcionário "+func.nome+" - "+(indice+1)+" - foi excluído com sucesso!!!");
  } else {
    alert(indice + " não é um índice válido!!!")
  }
}

function exibirInativos(){
  let lista = "";
  for(let i = 0; i < funcionarios.length; i++){
    const func = funcionarios[i];
  
    if(!func.ativo){
      let salarioLiquido = calcularSalarioLiquido(func.salarioBruto, func.experiencia);
  
      lista = lista + "["+func.ativo+"] Funcionário "+(i+1)+": Nome: " + func.nome + "; Motivo: " + func.motivo + "\n";
    }
  }
  alert("Funcionários: \n\n" + lista);    
}

function recuperarFuncionario(){
  const indice = parseInt(prompt("Digite o índice do funcionário: "));

  if(indice >= 0 && indice < funcionarios.length){
    const func = funcionarios[indice];

    func.ativo = true;
    func.motivo = "";

    alert("O Funcionário "+func.nome+" - "+(indice+1)+" - foi excluído com sucesso!!!");
  } else {
    alert(indice + " não é um índice válido!!!")
  }
}

function main(){
  let opcao;

  do{
    opcao = parseInt(prompt("Menu:\n" +
                      "1 - Incluir funcionário\n" +
                      "2 - Exibir todos\n" +
                      "3 - Exibir individual\n" +
                      "4 - Excluir funcionário\n" +
                      "5 - Exibir inativos\n" +
                      "6 - Recuperar funcionário\n" +
                      "7 - Sair"));

    switch(opcao){
      case 1:
        incluirFuncionario();
        break;
        
      case 2:
        exibirTodos();
        break;

      case 3:
        exibirIndividual();
        break;

      case 4:
        excluirFuncionario();
        break;

      case 5:
        exibirInativos();
        break;

      case 6:
        recuperarFuncionario();
        break;
  
      case 7:
        alert("Saindo do programa...");
        break;
        
      default:
        alert("Opção inválida!!!");
    }

  } while(opcao != 7);
}

main();