from os.path import dirname, join
import os
import glob

def executar_scripts(lista_arquivos):
    """
    Executa todos os scripts fornecidos
    """
    for arquivo_python in lista_arquivos:
        print(f"Executando {arquivo_python} ...")
        print()
        try:
            pasta_scripts = os.path.join(os.path.dirname(__file__), "questoes")
            comando_executar = f'python "{os.path.join(pasta_scripts, arquivo_python)}"'
            os.system(comando_executar)
        except Exception as erro:
            print(f"Erro ao executar o script {arquivo_python}: {erro}")
        print()
        print("#" * 30)


print("Qual script você gostaria de executar?")
caminho_questoes = os.path.join(os.path.dirname(__file__), "questoes")
lista_arquivos = sorted(os.listdir(caminho_questoes))

# Exibe a lista de arquivos disponíveis para execução
for indice, arquivo in enumerate(lista_arquivos):
    print(f"{indice + 1} - {arquivo}")

print(f"{len(lista_arquivos) + 1} - Executar todos")

opcao = input("Escolha uma opção: ")

try:
    opcao = int(opcao)
    if 1 <= opcao <= len(lista_arquivos):
        executar_scripts([lista_arquivos[opcao - 1]])  # Executa o script selecionado
    elif opcao == len(lista_arquivos) + 1:
        executar_scripts(lista_arquivos)  # Executa todos os scripts
    else:
        print("Opção inválida")
except ValueError:
    print("Entrada inválida. Por favor, insira um número.")
