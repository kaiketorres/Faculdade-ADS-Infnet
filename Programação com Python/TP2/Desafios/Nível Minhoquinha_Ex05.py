print(
    """
    Nível Minhoquinha | Ex 05: 
    Crie uma função chamada saudacao imprima uma saudação personalizada, como 'Olá, [nome do usuário]!', recebendo o nome como argumento da função.
    """
)
print()


def saudacao(nome):
    """
    Imprime uma saudação personalizada com o nome fornecido.

    Args:
        nome (str, optional): Nome do usuário para a saudação.

    Return:
        None
    """
    
    print(f"Olá, {nome}!")


saudacao("Kaike")
