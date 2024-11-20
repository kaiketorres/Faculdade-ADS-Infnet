function definir() {

    let nome = document.getElementById("nome").value 
  
    let email = document.getElementById("email").value
  
    let valorSigino = Number(document.getElementById("signo").value)
  
    let resultado = valorSigino
  
    let mensagem = (`Seu nome e ${nome} e seu E-mail e ${email} e seu signo e ${resultado}`)
  
    
  
    document.getElementById("resultado").value = mensagem
  }