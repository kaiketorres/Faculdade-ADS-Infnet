print(
    """
    Parte 1 | Exercício 3: 
    Crie uma função que receba um texto e devolva a palavra mais longa encontrada, ignorando a pontuação.
    """
)
print()

import string

def encontrar_palavra_mais_longa(frase):
    frase_sem_pontuacao = frase.translate(str.maketrans('', '', string.punctuation))
    lista_palavras = frase_sem_pontuacao.split()
    palavra_mais_longa = max(lista_palavras, key=len)
    return palavra_mais_longa

# Exemplo de utilização
frase_exemplo = "A perseverança frequentemente abre caminho para o sucesso, mesmo nos momentos mais desafiadores."
resultado = encontrar_palavra_mais_longa(frase_exemplo)
print("A palavra mais longa é:", resultado)
