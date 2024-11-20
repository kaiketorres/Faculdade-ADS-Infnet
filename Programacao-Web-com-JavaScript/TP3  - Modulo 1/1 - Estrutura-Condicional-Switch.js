const nivel = prompt("Nível");
switch (nivel.toLocaleLowerCase()) {
  case "estágio": console.log("R$ 1500.00");
  break
  case "trainee": console.log("R$ 2000.00");
  break
  case "júnior": console.log("R$ 2500.00"); 
  break
  case "pleno": console.log("R$ 4000.00"); 
  break
  case "sênior": console.log("R$ 6000.00"); 
  break
  default: console.log("Nível desconhecido.");
}
