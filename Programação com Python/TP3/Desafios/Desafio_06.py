print(
    """
    Parte 2 | Exercício 1: 
    Escreva um programa que calcule o resultado de uma expressão matemática básica fornecida como string pelo usuário, 
    ignorando espaços e permitindo apenas caracteres numéricos e os operadores +, -, * e /.
    Exemplo: '2 + 3 * 4' Resultado: 14.
    """
)
print()

def avaliar_expressao(equacao):
    equacao = equacao.replace(" ", "")
    resultado_final = 0
    valor_atual = ""
    operador_anterior = '+'
    
    for simbolo in equacao:
        if simbolo.isdigit():
            valor_atual += simbolo
        else:
            if valor_atual:
                if operador_anterior == '+':
                    resultado_final += int(valor_atual)
                elif operador_anterior == '-':
                    resultado_final -= int(valor_atual)
                elif operador_anterior == '*':
                    resultado_final *= int(valor_atual)
                elif operador_anterior == '/':
                    resultado_final /= int(valor_atual)
            operador_anterior = simbolo
            valor_atual = ""
    
    if valor_atual:
        if operador_anterior == '+':
            resultado_final += int(valor_atual)
        elif operador_anterior == '-':
            resultado_final -= int(valor_atual)
        elif operador_anterior == '*':
            resultado_final *= int(valor_atual)
        elif operador_anterior == '/':
            resultado_final /= int(valor_atual)
    
    return resultado_final

expressao_usuario = input("Informe a expressão matemática: ")
resultado_final = avaliar_expressao(expressao_usuario)
print(f"Resultado: {resultado_final}")
