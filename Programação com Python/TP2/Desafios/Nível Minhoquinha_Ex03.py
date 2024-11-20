print(
    """
    Nível Minhoquinha  | Ex 03: 
    Escreva um programa que receba uma lista de números (você pode definir a lista inicialmente, mas certifique-se que o código 
    funcionará para quaisquer listas numéricas) e utilize um loop for para calcular a média dos valores da lista.
    """
)
print()

valores = [10, 20, 30, 40, 50]

total = 0
for valor in valores:
    total += valor

media_aritmetica = total / len(valores)

print(media_aritmetica)
