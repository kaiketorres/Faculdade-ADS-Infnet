class Program
{
    static string caminhoArquivo = "contatos.txt";
    
    static void Main()
    {
        List<Contato> contatos = CarregarContatos();
        
        Console.WriteLine("Deseja adicionar um novo contato? (s/n)");
        if (Console.ReadLine().ToLower() == "s")
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            contatos.Add(new Contato(nome, telefone, email));
            SalvarContatos(contatos);
        }
        
        Console.WriteLine("Escolha o formato de exibição: 1 - Markdown, 2 - Tabela, 3 - Texto Puro");
        int escolha = int.Parse(Console.ReadLine());
        
        ContatoFormatter formatter = escolha switch
        {
            1 => new MarkdownFormatter(),
            2 => new TabelaFormatter(),
            3 => new RawTextFormatter(),
            _ => throw new ArgumentException("Opção inválida")
        };
        
        formatter.ExibirContatos(contatos);
    }
    
    static List<Contato> CarregarContatos()
    {
        List<Contato> contatos = new List<Contato>();
        if (File.Exists(caminhoArquivo))
        {
            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var dados = linha.Split(';');
                if (dados.Length == 3)
                {
                    contatos.Add(new Contato(dados[0], dados[1], dados[2]));
                }
            }
        }
        return contatos;
    }
    
    static void SalvarContatos(List<Contato> contatos)
    {
        using (StreamWriter writer = new StreamWriter(caminhoArquivo))
        {
            foreach (var contato in contatos)
            {
                writer.WriteLine($"{contato.Nome};{contato.Telefone};{contato.Email}");
            }
        }
    }
}