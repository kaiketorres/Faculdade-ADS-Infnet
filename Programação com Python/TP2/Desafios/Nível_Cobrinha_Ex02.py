print(
    """
    Nível Cobrinha | Ex 02:
    Crie uma função chamada maior_valor que receba três números como três argumentos posicionais, exiba o maior número na tela e 
    retorne uma lista ordenada contendo estes números.
    """
)
print()

def maior_valor(num1, num2, num3):
    """
    Exibe o maior número entre três fornecidos e retorna uma lista ordenada com esses números.

    Args:
        num1 (int | float): O primeiro número.
        num2 (int | float): O segundo número.
        num3 (int | float): O terceiro número.

    Returns:
        list: Lista com os números fornecidos ordenados de forma crescente.
    """
    maior_numero = max(num1, num2, num3)
    print(maior_numero)
    return sorted([num1, num2, num3])

resultado = maior_valor(7, 3, 5)
print(resultado)
