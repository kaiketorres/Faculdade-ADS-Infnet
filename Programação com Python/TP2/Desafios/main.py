from os.path import dirname, join
import os

def executar_scripts(lista_arquivos):
    """
    Executa todos os scripts fornecidos.
    """
    for arquivo in lista_arquivos:
        print(f"Iniciando execução do script: {arquivo} ...")
        print()
        try:
            diretorio_scripts = os.path.join(os.path.dirname(__file__), "scripts")
            comando = f'python "{os.path.join(diretorio_scripts, arquivo)}"'
            os.system(comando)
        except Exception as erro:
            print(f"Erro ao executar o script {arquivo}: {erro}")
        print()
        print("#" * 30)

print("Qual script você gostaria de executar?")
caminho_scripts = os.path.join(os.path.dirname(__file__), "scripts")
arquivos = sorted(os.listdir(caminho_scripts))

# Exibe a lista de arquivos e suas opções
for indice, arquivo in enumerate(arquivos):
    print(f"{indice + 1} - {arquivo}")

print(f"{len(arquivos) + 1} - Executar todos")

opcao = input("Selecione uma opção: ")

try:
    opcao = int(opcao)
    if 1 <= opcao <= len(arquivos):
        executar_scripts([arquivos[opcao - 1]])  # Ajustado para garantir a execução correta
    elif opcao == len(arquivos) + 1:
        executar_scripts(arquivos)  # Executa todos os arquivos
    else:
        print("Opção inválida.")
except ValueError:
    print("Entrada inválida. Por favor, insira um número.")
