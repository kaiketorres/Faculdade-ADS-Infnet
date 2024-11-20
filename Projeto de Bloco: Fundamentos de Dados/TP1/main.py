import datetime
from enum import Enum
import os
import time

lista_tarefas = []

def esperando_redirecionamento():
    """
    Mostra um 'Redirecionando' com pontinhos só pra passar o tempo.
    """
    mensagem = "Redirecionando"
    print(mensagem, end="", flush=True)
    for i in range(5):
        time.sleep(1)  # Pausa de 1 segundo
        print(".", end="", flush=True)
    print()  # Quebra a linha no final

def pegar_ultimo_id():
    """
    Pega o maior ID das tarefas, ou começa do zero se não tiver nada.

    Returns:
        int: O maior ID ou 0 se a lista estiver vazia.
    """
    if not lista_tarefas:
        return 0
    return max(tarefa.id for tarefa in lista_tarefas)

class Situacao(Enum):
    """
    Status da tarefa. É o que indica se ela tá pendente, em andamento, ou já foi feita.
    """
    A_Fazer = 1
    Fazendo = 2
    Feito = 3

class Urgencia(Enum):
    """
    A prioridade da tarefa. Basicamente, se é algo urgente ou pode esperar.
    """
    Alta = 1
    Media = 2
    Baixa = 3

class Atividade:
    def __init__(self, descricao, prazo_final, prioridade):
        """
        Representa uma atividade. Aqui você cria a tarefa, define o prazo e a urgência.

        Args:
            descricao (str): O que é pra fazer.
            prazo_final (str): Quando tem que tá pronto (formato: "dd/mm/aaaa").
            prioridade (int): Prioridade da tarefa (1-alta, 2-média, 3-baixa).
        """
        self.id = pegar_ultimo_id() + 1
        self.descricao = descricao
        self.data_criacao = datetime.datetime.now()
        self.status = Situacao(1)
        self.prazo_final = datetime.datetime.strptime(prazo_final, "%d/%m/%Y")
        self.prioridade = int(prioridade)

# Adiciona umas tarefas só pra testar
lista_tarefas.append(Atividade("Teste1", "01/09/2024", 1))
lista_tarefas.append(Atividade("Teste2", "01/09/2024", 2))
lista_tarefas.append(Atividade("Teste3", "01/09/2024", 3))

def adicionar_atividade():
    """
    Adiciona uma nova atividade na lista. Pede pro usuário digitar os detalhes.
    """
    descricao = input("O que você precisa fazer? ")
    prazo_final = input("Quando precisa estar pronto? (formato: dd/mm/aaaa): ")
    prioridade = input("Qual a urgência? (1-alta, 2-média, 3-baixa): ")
    atividade = Atividade(descricao, prazo_final, prioridade)
    lista_tarefas.append(atividade)

def excluir_atividade():
    """
    Remove uma atividade da lista, baseada no ID que o usuário escolhe.
    """
    id = selecionar_atividade()
    for atividade in lista_tarefas:
        if atividade.id == id:
            lista_tarefas.remove(atividade)
            break
    else:
        print(f"Ops, não achei a tarefa {id}.")

def mudar_situacao():
    """
    Troca o status da atividade, tipo de pendente pra em andamento ou concluído.
    """
    id = selecionar_atividade()
    status = int(input("Qual o status agora? (1-A_Fazer, 2-Fazendo, 3-Feito): "))
    for atividade in lista_tarefas:
        if atividade.id == id:
            atividade.status = Situacao(status)
            return
    print(f"Ops, não achei a tarefa {id}.")

def selecionar_atividade():
    """
    Pede pra você escolher uma atividade pelo ID dela.

    Returns:
        int: O ID da atividade que você digitou.
    """
    return int(input("Qual o ID da atividade? "))

def mudar_urgencia():
    """
    Troca a prioridade de uma atividade, se ela ficou mais urgente ou menos.
    """
    id = selecionar_atividade()
    prioridade = int(input("E a urgência, qual vai ser agora? (1-alta, 2-média, 3-baixa): "))
    for atividade in lista_tarefas:
        if atividade.id == id:
            atividade.prioridade = Urgencia(prioridade)
            return
    print(f"Ops, não achei a tarefa {id}.")

def listar_atividades():
    """
    Mostra todas as atividades com os detalhes. Pra você saber o que tá rolando.
    """
    print("========= Suas Tarefas =========")
    if len(lista_tarefas) < 1:
        print(">>>>> Sem tarefas no momento! Aproveite o descanso. <<<<<")
    else:
        for atividade in lista_tarefas:
            print(f"{atividade.id} | "
                  f"{atividade.descricao} | "
                  f"{atividade.data_criacao.strftime('%d/%m/%Y')} | "
                  f"{Situacao(atividade.status).name} | "
                  f"{atividade.prazo_final.strftime('%d/%m/%Y')} | "
                  f"{Urgencia(atividade.prioridade).name}")
    print("================================")

def mostrar_acoes():
    """
    Lista o que você pode fazer com as tarefas. Escolha o que precisa.
    """
    print("========== O que você quer fazer? ==========")    
    print(f"\n1 - Adicionar uma nova tarefa")
    if len(lista_tarefas) > 0:
        print(f"\n2 - Excluir uma tarefa")
        print(f"\n3 - Mudar status de uma tarefa")
        print(f"\n4 - Mudar urgência de uma tarefa")
    print(f"\n5 - Sair")
    print("============================================")

def escolher_acao():
    """
    Deixa você escolher uma das opções disponíveis.

    Returns:
        int: A opção escolhida.
    """
    entrada = input("Escolha uma opção: ")
    print(f"[{entrada.strip()}]")
    if entrada.strip() == "":
        return 0
    return int(entrada)

def menu_principal():
    """
    Mostra o menu principal e executa a ação que você escolher.
    """
    limpar_terminal()
    listar_atividades()
    mostrar_acoes()
    acao = escolher_acao()
    if acao == 0:
        menu_principal()
    elif acao == 1:
        adicionar_atividade()
        esperando_redirecionamento()
        menu_principal()
    elif acao == 2:
        excluir_atividade()
        esperando_redirecionamento()
        menu_principal()
    elif acao == 3:
        mudar_situacao()
        esperando_redirecionamento()
        menu_principal()
    elif acao == 4:
        mudar_urgencia()
        esperando_redirecionamento()
        menu_principal()
    elif acao == 5:
        print("Valeu, até a próxima!")
        return
    else:
        menu_principal()

def limpar_terminal():
    """
    Limpa a tela do terminal. Pra dar uma organizada na visualização.
    """
    os.system('cls' if os.name == 'nt' else 'clear')

limpar_terminal()
menu_principal()
