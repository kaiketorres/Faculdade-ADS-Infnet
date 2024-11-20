print(
    """
    Nível Python | Ex 04: 
    Quando o usuário digitar ‘Fim’ uma função (pode utilizar mais de uma função) deverá receber as duas listas do item anterior como 
    argumentos, calcular a média das temperaturas, ponderada pelo intervalo de tempo entre as medidas e imprimir se a média está dentro 
    do intervalo de segurança (20°C a 30°C) e exibir o horário e o valor da temperatura mais baixa e mais alta do dia.
    """
)
print()

def calcular_media_temperatura(horas, temps):
    if not horas or not temps or len(horas) != len(temps):
        return None

    tempo_total = 0
    temperatura_ponderada_total = 0

    for i in range(len(horas) - 1):
        intervalo = horas[i + 1] - horas[i]
        tempo_total += intervalo
        temperatura_ponderada_total += temps[i] * intervalo

    if tempo_total == 0:
        return None

    return temperatura_ponderada_total / tempo_total

def verificar_intervalo_adequado(media_temperatura):
    return 20 <= media_temperatura <= 30

def mostrar_dados_final(horas, temps):
    if not horas or not temps:
        print("Nenhum dado disponível.")
        return

    media_temperatura = calcular_media_temperatura(horas, temps)

    if media_temperatura is not None:
        if verificar_intervalo_adequado(media_temperatura):
            print(
                f"Média ponderada das temperaturas: {media_temperatura:.2f}°C está dentro do intervalo de segurança."
            )
        else:
            print(
                f"Média ponderada das temperaturas: {media_temperatura:.2f}°C está fora do intervalo de segurança."
            )
    else:
        print("Não foi possível calcular a média ponderada.")

    temp_min = min(temps)
    temp_max = max(temps)
    hora_min = horas[temps.index(temp_min)]
    hora_max = horas[temps.index(temp_max)]

    print(f"Temperatura mais baixa: {temp_min:.2f}°C às {hora_min}h")
    print(f"Temperatura mais alta: {temp_max:.2f}°C às {hora_max}h")

horarios = []
temperaturas = []

while True:
    hora_input = input("Informe a hora do registro (ou 'Fim' para encerrar): ")
    if hora_input.lower() == "fim":
        break

    try:
        hora_registro = int(hora_input)
        if hora_registro < 0 or hora_registro > 23:
            print("Hora inválida.")
            continue

        temperatura_input = input("Informe o valor da temperatura registrada: ")
        temp_registrada = float(temperatura_input)
        if temp_registrada < -15 or temp_registrada > 60:
            print("Temperatura inválida.")
            continue

        horarios.append(hora_registro)
        temperaturas.append(temp_registrada)

    except ValueError:
        print("Entrada inválida.")

mostrar_dados_final(horarios, temperaturas)
