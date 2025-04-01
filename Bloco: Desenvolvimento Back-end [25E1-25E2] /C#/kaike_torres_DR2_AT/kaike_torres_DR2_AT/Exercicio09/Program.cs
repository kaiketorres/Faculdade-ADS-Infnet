class Program
{
    static void Main(string[] args)
    {
        Produto[] produtos = new Produto[5]; // Limite de 5 produtos
        int count = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu de Opções:");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                if (count >= 5)
                {
                    Console.WriteLine("Limite de produtos atingido!");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("Digite o nome do produto: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite a quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    Console.Write("Digite o preço unitário: ");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    produtos[count] = new Produto(nome, quantidade, preco);
                    count++;

                    Console.WriteLine("Produto inserido com sucesso!");
                    Console.ReadKey();
                }
            }
            else if (opcao == "2")
            {
                if (count == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    Console.WriteLine("Lista de Produtos:");
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"Produto: {produtos[i].Nome} | Quantidade: {produtos[i].Quantidade} | Preço: R$ {produtos[i].Preco:F2}");
                    }
                }
                Console.ReadKey();
            }
            else if (opcao == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                Console.ReadKey();
            }
        }
    }
}