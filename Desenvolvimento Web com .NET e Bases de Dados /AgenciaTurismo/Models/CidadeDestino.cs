namespace AgenciaTurismo.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Correção: inicializa string

        public int PaisDestinoId { get; set; }
        public PaisDestino? Pais { get; set; } // Correção: torna anulável, pois pode não ser carregada pelo EF Core

        public List<PacoteTuristico> PacotesTuristicos { get; set; } = new List<PacoteTuristico>();
    }
}
