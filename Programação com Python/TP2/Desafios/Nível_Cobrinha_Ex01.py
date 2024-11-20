print(
    """
    Nível Cobrinha | Ex 01: 
    Defina uma função chamada potencia que receba dois números como argumento, a base e o expoente. O expoente deve ter um valor padrão de 2. 
    A função deve calcular e retornar a base elevada ao expoente.
    """
)
print()

def potencia(base, expoente=2):
    """
    Calcula a base elevada ao expoente.

    Args:
        base (int | float): A base a ser elevada.
        expoente (int, optional): O expoente ao qual a base será elevada. O padrão é 2.
    
    Returns:
        int | float: O resultado da base elevada ao expoente.
    """
    return base ** expoente

resultado1 = potencia(3, 4)
print(resultado1)  

resultado2 = potencia(5)
print(resultado2) 
