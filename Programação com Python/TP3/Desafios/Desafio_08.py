print(
    """
    Parte 3 | Mini Projeto 1: 
    Validação e Formatação de Dados em um Sistema de Cadastro

    Crie um programa em Python para solicitar ao usuário os seguintes dados e validá-los:
    
    1. CPF: Deve ter 11 dígitos e ser formatado como "xxx.xxx.xxx-xx".
    2. E-mail: Deve ser um e-mail válido com "@" e um domínio (alfanuméricos + ‘@’ + alfanuméricos + ‘.’ + alfabéticos).
    3. Telefone: Deve remover caracteres não numéricos e ser formatado como (XX) XXXXX-XXXX ou (XX) XXXX-XXXX.
    """
)
print()

import re

def obter_cpf():
    return input("Digite o CPF: ").strip()

def obter_email():
    return input("Digite o e-mail: ").strip().lower()

def obter_telefone():
    return input("Digite o telefone: ").strip()

def valida_cpf(cpf):
    cpf_digits = [char for char in cpf if char.isdigit()]
    if len(cpf_digits) != 11:
        return ["Inconsistência no campo CPF: Deve conter 11 dígitos."]
    return []

def valida_email(email):
    padrao_email = r"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"
    if not re.match(padrao_email, email):
        return ["Inconsistência no campo E-mail: Formato inválido."]
    return []

def valida_telefone(telefone):
    telefone_digits = [char for char in telefone if char.isdigit()]
    if len(telefone_digits) not in [10, 11]:
        return ["Inconsistência no campo Telefone: Deve conter 10 ou 11 dígitos."]
    return []

def formata_cpf(cpf_digits):
    cpf = ''.join(cpf_digits)
    return f"{cpf[:3]}.{cpf[3:6]}.{cpf[6:9]}-{cpf[9:]}"

def formata_telefone(telefone_digits):
    telefone = ''.join(telefone_digits)
    if len(telefone) == 11:
        return f"({telefone[:2]}) {telefone[2:7]}-{telefone[7:]}"
    else:
        return f"({telefone[:2]}) {telefone[2:6]}-{telefone[6:]}"


def inicio():
    cpf = obter_cpf()
    email = obter_email()
    telefone = obter_telefone()

    inconsistencias = []
    
    inconsistencias.extend(valida_cpf(cpf))
    inconsistencias.extend(valida_email(email))
    inconsistencias.extend(valida_telefone(telefone))
    
    if inconsistencias:
        for inconsistencia in inconsistencias:
            print(inconsistencia)
    else:
        cpf_digits = [char for char in cpf if char.isdigit()]
        telefone_digits = [char for char in telefone if char.isdigit()]
        print()
        print("Resultado:")
        print(f"CPF: {formata_cpf(cpf_digits)}")
        print(f"E-mail: {email}")
        print(f"Telefone: {formata_telefone(telefone_digits)} (formato string)")
        print(f"Telefone (número inteiro): {''.join(telefone_digits)}")

inicio()
