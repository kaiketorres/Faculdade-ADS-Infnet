print(
    """
    Nível Python | Ex 02: 
    Cálculo de Consumo de Combustível
    Escreva um programa que ajude um motorista a calcular o consumo de combustível de seu veículo. O programa deve solicitar ao usuário que insira a 
    distância percorrida e a quantidade de combustível consumido em várias viagens. Essas informações devem ser armazenadas em uma lista. 
    Em seguida, crie uma função que percorra essa lista e calcule o consumo médio de combustível (km/l) para cada viagem e para o total de todas as viagens.

    Monitoramento de Temperatura

    Você foi contratado para desenvolver um software que monitora as temperaturas registradas por sensores em uma fábrica ao longo do dia. 
    """
)
print()

def calcular_consumo(dados_viagens):
    consumos_individuais = []
    distancia_total = 0
    combustivel_total = 0

    for distancia, combustivel in dados_viagens:
        consumo = distancia / combustivel
        consumos_individuais.append(consumo)
        distancia_total += distancia
        combustivel_total += combustivel

    consumo_medio_total = (
        distancia_total / combustivel_total if combustivel_total > 0 else 0
    )

    return consumos_individuais, consumo_medio_total

registros_viagens = []
while True:
    distancia = float(input("Informe a distância percorrida (ou 0 para encerrar): "))
    if distancia == 0:
        break
    combustivel = float(input("Informe a quantidade de combustível consumido: "))
    registros_viagens.append((distancia, combustivel))

consumos, consumo_medio_total = calcular_consumo(registros_viagens)

for i, consumo in enumerate(consumos, start=1):
    print(f"Consumo da viagem {i}: {consumo:.2f} km/l")

print(f"Consumo médio total: {consumo_medio_total:.2f} km/l")
