print(
    """
    Parte 1 | Exercício 4: 
    Escreva um programa que peça ao usuário uma frase e mostre o número de caracteres, de palavras, e de espaços em branco presentes na frase.
    """
)
print()

frase_usuario = input("Informe uma frase: ")
total_caracteres = len(frase_usuario)
total_palavras = len(frase_usuario.split())
total_espacos = frase_usuario.count(' ')

print(f"Total de caracteres: {total_caracteres}")
print(f"Total de palavras: {total_palavras}")
print(f"Total de espaços em branco: {total_espacos}")
