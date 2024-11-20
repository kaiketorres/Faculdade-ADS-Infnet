print(
    """
    Nível Minhoquinha | Ex 6: 
    Usando a mesma implementação da questão 5 modifique a função para que, caso nenhum argumento seja passado, exiba uma saudação genérica.
    """
)
print()


def saudacao(nome=None):
    """
    Exibe uma saudação específica com base no nome dado.
    Caso nenhum nome seja informado, exibe uma saudação padrão.
    
    Argumentos:
        nome (str, opcional): Nome da pessoa para a saudação. Se não informado, será mostrada uma saudação padrão.
    
    Retorno:
        Nenhum
    """

   
    if nome:
        print(f"Olá, {nome}!")
    else:
        print("Olá!")

saudacao()
