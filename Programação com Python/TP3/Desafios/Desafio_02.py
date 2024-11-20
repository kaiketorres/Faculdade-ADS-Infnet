print(
    """
    Parte 1 | Exercício 2: 
    Escreva um script em Python que troque todas as ocorrências de uma palavra específica em uma frase 
    por outra palavra escolhida pelo usuário. Utilize um texto de exemplo de sua preferência e escolha a 
    palavra a ser trocada, mas a lógica deve funcionar para outros casos.
    """
)
print()

texto_original = "O jardim está cheio de flores coloridas e fragrâncias suaves."
palavra_original = input("Informe a palavra que deseja substituir: ")
palavra_nova = input("Informe a nova palavra: ")

texto_atualizado = texto_original.replace(palavra_original, palavra_nova)
print("Texto atualizado:", texto_atualizado)
