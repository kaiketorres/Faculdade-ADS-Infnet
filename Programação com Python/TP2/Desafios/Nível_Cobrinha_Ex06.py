print(
    """
    Nível Cobrinha | Ex 06:
    Defina uma função chamada gerar_lista_pares que receba um número n, fornecido pelo usuário, como argumento e retorne uma 
    lista contendo todos os números pares de 0 até n. Utilize um laço for para preencher a lista.
    """
)
print()

def gerar_lista_pares(limite):
    pares = []
    for numero in range(0, limite + 1, 2):
        pares.append(numero)
    return pares

numero_usuario = int(input("Digite um número: "))
lista_pares = gerar_lista_pares(numero_usuario)
print(lista_pares)
