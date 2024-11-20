print(
    """
    Nível Cobrinha | Ex 05:
    Defina uma função chamada exibir_mensagem que receba um argumento obrigatório mensagem e um argumento opcional repeticoes, 
    onde repeticoes tem um valor padrão de 1. A função deve imprimir a mensagem o número de vezes especificado por repeticoes.
    """
)
print()

def exibir_mensagem(texto, vezes=1):
    for _ in range(vezes):
        print(texto)

exibir_mensagem("kaike", vezes=3)
