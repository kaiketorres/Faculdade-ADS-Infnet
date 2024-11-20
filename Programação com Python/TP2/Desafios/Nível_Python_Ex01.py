print(
    """
    Nível Python | Ex 01: 
    Simulador de Investimentos
    Crie um programa que simule o crescimento de um investimento ao longo de um período. O programa deve solicitar ao usuário o valor inicial do 
    investimento, a taxa de juros anual e o número de anos. Em seguida, escreva uma função que calcule o valor final do investimento ao final de 
    cada ano e armazene esses valores em uma lista. Imprima o valor acumulado ano a ano (lembre-se que se trata de juros compostos).
    """
)
print()

def calcular_valores_investimento(valor_investido, taxa_juros, periodo):
    resultados = []
    valor_total = valor_investido
    taxa_decimal = taxa_juros / 100

    for ano in range(1, periodo + 1):
        valor_total *= 1 + taxa_decimal
        resultados.append(valor_total)

    return resultados

valor_investido = float(input("Informe o valor inicial do investimento: "))
taxa_juros = float(input("Informe a taxa de juros anual (em %): "))
periodo = int(input("Informe o número de anos: "))

valores_finais = calcular_valores_investimento(
    valor_investido, taxa_juros, periodo
)

for ano, valor in enumerate(valores_finais, start=1):
    print(f"Ano {ano}: R${valor:.2f}")
