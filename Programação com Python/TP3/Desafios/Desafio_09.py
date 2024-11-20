print(
    """
    Parte 3 | Mini Projeto 2: Análise de Dados de Vendas 

    Implemente um programa em Python que receba uma lista de transações no formato "ID_do_Produto,Nome_do_Produto,Quantidade,Valor_Unitário" e realize as seguintes tarefas:
    
    1. Calcule e exiba o valor total das vendas para cada produto.
    2. Identifique o produto mais vendido (baseado na quantidade) e o produto que gerou a maior receita total.
    3. Converta os valores totais de vendas para uma nova moeda, utilizando um fator de conversão fornecido pelo usuário, e exiba os valores convertidos no formato monetário adequado.
    """
)
print()

# Lista de transações
transacoes = [
    "1,Placa de Vídeo,15,1200.00",
    "2,Processador,8,800.00",
    "3,Memória RAM,20,300.00",
    "4,SSD,10,500.00",
    "5,Fonte,5,150.00"
]

transacoes_lista = []

def obter_conversao():
    return float(input("Digite o fator de conversão para a nova moeda: "))

def listar_transacoes():    
    for transacao in transacoes:
        partes = transacao.split(',')
        id_transacao, nome_transacao, qtd, preco_unitario = partes
        qtd = int(qtd)
        preco_unitario = float(preco_unitario)
        transacoes_lista.append({
            'id': id_transacao,
            'nome': nome_transacao,
            'quantidade': qtd,
            'preco_unitario': preco_unitario
        })

listar_transacoes()

def calcula_vendas(transacoes_lista):
    resultado_vendas = {}
    for transacao in transacoes_lista:
        nome_transacao = transacao['nome']
        qtd = transacao['quantidade']
        preco_unitario = transacao['preco_unitario']

        if nome_transacao not in resultado_vendas:
            resultado_vendas[nome_transacao] = {'quantidade': 0, 'total': 0.0}
        
        resultado_vendas[nome_transacao]['quantidade'] += qtd
        resultado_vendas[nome_transacao]['total'] += qtd * preco_unitario
    
    return resultado_vendas

def transacao_mais_vendida(resultado_vendas):
    transacao = max(resultado_vendas, key=lambda t: resultado_vendas[t]['quantidade'])
    return transacao, resultado_vendas[transacao]['quantidade']

def transacao_maior_receita(resultado_vendas):
    transacao = max(resultado_vendas, key=lambda t: resultado_vendas[t]['total'])
    return transacao, resultado_vendas[transacao]['total']

def converter_valores(valores_totais, fator_conversao):
    return {transacao: total * fator_conversao for transacao, total in valores_totais.items()}

def mostrar_resultados(resultado_vendas, valores_convertidos):
    print("Total:")
    for transacao, dados in resultado_vendas.items():
        print(f"{transacao}: R$ {dados['total']:.2f}")
    
    transacao_mais_vendida_nome, qtd = transacao_mais_vendida(resultado_vendas)
    transacao_maior_receita_nome, receita = transacao_maior_receita(resultado_vendas)
    
    print(f"\nProduto mais vendido: {transacao_mais_vendida_nome} com {qtd} unidades vendidas")
    print(f"Produto com maior receita: {transacao_maior_receita_nome} com R$ {receita:.2f}")
    
    print("\nValores totais das vendas convertidos:")
    for transacao, total_convertido in valores_convertidos.items():
        print(f"{transacao}: {total_convertido:.2f}")

def iniciar():
    fator_conversao = obter_conversao()
    resultado_vendas = calcula_vendas(transacoes_lista)
    valores_totais = {transacao: dados['total'] for transacao, dados in resultado_vendas.items()}
    valores_convertidos = converter_valores(valores_totais, fator_conversao)
    mostrar_resultados(resultado_vendas, valores_convertidos)

iniciar()
