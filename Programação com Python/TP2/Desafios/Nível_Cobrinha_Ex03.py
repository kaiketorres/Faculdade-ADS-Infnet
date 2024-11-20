print(
    """
    Nível Cobrinha | Ex 03:
    Crie uma função chamada imprime_dados que recebe diversos dados de um produto (nome, preço, quantidade em estoque) 
    como argumentos passados obrigatoriamente por palavras-chave e os imprima de forma organizada.
    """
)
print()

def imprime_dados(*, produto, valor, estoque):
    """
    Exibe informações detalhadas sobre um produto de maneira organizada.

    Args:
        produto (str): Nome do produto.
        valor (float): Preço do produto.
        estoque (int): Quantidade disponível do produto.

    Returns:
        None
    """
    print(f"Nome do produto: {produto}")
    print(f"Preço: R${valor:.2f}")
    print(f"Quantidade em estoque: {estoque}")

imprime_dados(produto="Produto X", valor=29.89, estoque=37)
