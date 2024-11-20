print(
    """
    Parte 2 | Exercício 2: 
    Crie uma função que receba uma string representando uma data no formato "dd/mm/aaaa" e 
    retorne a data por extenso, por exemplo, "25/12/2024" -> "Vinte e cinco de dezembro 
    de dois mil e vinte e quatro".
    """
)
print()

unidades = ["zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove"]
dezenas = ["", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa"]
especiais = ["onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove"]
meses = ["janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"]

def converter_numero_extenso(numero):
    if 0 <= numero <= 9:
        return unidades[numero]
    elif 10 <= numero <= 19:
        return especiais[numero - 11]
    elif 20 <= numero <= 99:
        dezena = numero // 10
        unidade = numero % 10
        if unidade == 0:
            return dezenas[dezena]
        else:
            return f"{dezenas[dezena]} e {unidades[unidade]}"
    elif 100 <= numero <= 999:
        centena = numero // 100
        restante = numero % 100
        if restante == 0:
            if centena == 1:
                return "cem"
            else:
                return f"{unidades[centena]} centos"
        else:
            return f"{unidades[centena]} centos e {converter_numero_extenso(restante)}"
    elif 1000 <= numero <= 9999:
        milhar = numero // 1000
        restante = numero % 1000
        if restante == 0:
            if milhar == 1:
                return "mil"
            else:
                return f"{unidades[milhar]} mil"
        else:
            return f"{unidades[milhar]} mil e {converter_numero_extenso(restante)}"
    else:
        raise ValueError("Número fora do intervalo suportado.")

def converter_dia_extenso(dia):
    return converter_numero_extenso(dia)

def converter_mes_extenso(mes_num):
    return meses[mes_num - 1]

def converter_ano_extenso(ano):
    return converter_numero_extenso(ano)

def data_por_extenso(data):
    dia, mes_num, ano = map(int, data.split('/'))
    dia_extenso = converter_dia_extenso(dia)
    mes_extenso = converter_mes_extenso(mes_num)
    ano_extenso = converter_ano_extenso(ano)
    return f"{dia_extenso.capitalize()} de {mes_extenso} de {ano_extenso}"

# Exemplo de utilização
data_informada = input("Informe a data no formato dd/mm/aaaa: ")
resultado_data = data_por_extenso(data_informada)
print(f"Data por extenso: {resultado_data}")
