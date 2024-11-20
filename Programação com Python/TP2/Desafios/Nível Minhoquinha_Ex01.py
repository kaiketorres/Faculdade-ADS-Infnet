print(
    """
    Nível Minhoquinha  | Ex 01: 
    Crie um programa que receba uma string como entrada do usuário e use um loop for para criar uma lista com cada caractere da string.
    """
)
print()

texto = input("Digite uma string: ")
caracteres_separados = []

for letra in texto:
    caracteres_separados.append(letra)

print("Lista de caracteres:", caracteres_separados)
