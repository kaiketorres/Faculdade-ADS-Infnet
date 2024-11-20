let cargo =  window.prompt("Digite o seu cargo")

let salario = parseFloat(window.prompt("Digite o seu salario"))

switch(cargo){
    case "estagiario": salario *= 1.10;
    break
    case "trainee": salario *= 1.09;
    break
    case "júnior": salario *= 1.08;
    break
    case "pleno": salario *= 1.07;
    break
    case "sênior": salario *= 1.06;
    break
    default: window.alert("Este cargo não é conhecido")
}




