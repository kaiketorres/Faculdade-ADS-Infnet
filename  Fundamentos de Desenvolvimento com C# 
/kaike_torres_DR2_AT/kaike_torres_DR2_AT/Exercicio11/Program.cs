class Program
{
    static string caminhoArquivo = "contatos.txt";
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    AdicionarContato();
                    break;
                case "2":
                    ListarContatos();
                    break;
                case "3":
                    Console.WriteLine("Encerrando programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
    
    static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
        {
            writer.WriteLine($"{nome},{telefone},{email}");
        }

        Console.WriteLine("Contato cadastrado com sucesso!\n");
    }
    
    static void ListarContatos()
    {
        if (!File.Exists(caminhoArquivo) || new FileInfo(caminhoArquivo).Length == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.\n");
            return;
        }
        
        Console.WriteLine("Contatos cadastrados:");
        foreach (var linha in File.ReadAllLines(caminhoArquivo))
        {
            var dados = linha.Split(',');
            if (dados.Length == 3)
            {
                Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
            }
        }
        Console.WriteLine();
    }
}
