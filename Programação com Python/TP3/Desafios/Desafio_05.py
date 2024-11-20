print(
    """
    Parte 1 | Exercício 5: 
    Desenvolva um programa para calcular a soma dos dígitos em uma string numérica fornecida pelo usuário, 
    verificando se todos os caracteres são numéricos.
    Exemplo: “123” Resultado: 1+2+3 = 6
    """
)
print()

string_numerica = input("Informe uma string numérica: ")

if string_numerica.isdigit():
    soma_digitos = sum(int(numero) for numero in string_numerica)
    print(f"Soma dos dígitos: {soma_digitos}")
else:
    print("A string contém caracteres não numéricos.")
