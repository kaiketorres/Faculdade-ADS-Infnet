class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("| Nome           | Telefone        | Email            |");
        Console.WriteLine("----------------------------------------");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome,-14} | {contato.Telefone,-14} | {contato.Email,-16} |");
        }
        Console.WriteLine("----------------------------------------");
    }
}