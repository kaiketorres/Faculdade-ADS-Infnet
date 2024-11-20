      // Solicitar ao usuário os tamanhos dos três lados
      let lado1 = parseFloat(prompt("Digite o tamanho do primeiro lado do triângulo:"));
      let lado2 = parseFloat(prompt("Digite o tamanho do segundo lado do triângulo:"));
      let lado3 = parseFloat(prompt("Digite o tamanho do terceiro lado do triângulo:"));

      // Verificar se os tamanhos informados formam um triângulo
      if (lado1 + lado2 > lado3 && lado1 + lado3 > lado2 && lado2 + lado3 > lado1) {
          console.log("Os três valores informados podem formar um triângulo.");
      } else {
          console.log("Os três valores informados NÃO podem formar um triângulo.");
      }
