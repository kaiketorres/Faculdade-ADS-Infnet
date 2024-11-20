print(
    """
    Parte 1 | Questão 1: 
    Desenvolva um programa que solicite um nome completo ao usuário, formate-o de forma que todas as 
    palavras iniciem com a primeira letra maiúscula e as demais minúsculas, exibindo-o na tela.
    """
)
print()

nome_pessoa = input("Por favor, digite seu nome completo: ")

nome_formatado = nome_pessoa.title()

print("Nome formatado:", nome_formatado)
