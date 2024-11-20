print(
    """
    Nível Python | Ex 03:  
    Escreva um programa que utilize um laço while para solicitar ao usuário que informe a hora do registro da temperatura (em um número inteiro) 
    seguido do valor da temperatura registrada. Seu programa deverá conter função de validação da entrada do usuário para garantir que a hora descrita 
    esteja entre 0h e 23h e que a temperatura informada esteja entre -15ºC e 60ºC. E em seguida armazene as informações em duas listas, uma com os horários 
    e outra com as temperaturas.
    """
)
print()

def validar_hora(hora_registro):
    return 0 <= hora_registro <= 23

def validar_temperatura(temp_registrada):
    return -15 <= temp_registrada <= 60

horarios_registros = []
temperaturas_registradas = []

while True:
    hora_input = input("Informe a hora do registro (ou 'sair' para encerrar): ")
    if hora_input.lower() == "sair":
        break

    try:
        hora_registro = int(hora_input)
        if not validar_hora(hora_registro):
            print("Hora inválida.")
            continue

        temperatura_input = input("Informe o valor da temperatura registrada: ")
        temp_registrada = float(temperatura_input)
        if not validar_temperatura(temp_registrada):
            print("Temperatura inválida.")
            continue

        horarios_registros.append(hora_registro)
        temperaturas_registradas.append(temp_registrada)

    except ValueError:
        print("Entrada inválida.")

for hora, temperatura in zip(horarios_registros, temperaturas_registradas):
    print(f"Hora: {hora}h, Temperatura: {temperatura:.2f}°C")
