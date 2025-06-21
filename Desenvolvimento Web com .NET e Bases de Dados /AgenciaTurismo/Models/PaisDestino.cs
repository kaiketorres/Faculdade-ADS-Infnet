using System.Collections.Generic;

namespace AgenciaTurismo.Models
{
    public class PaisDestino
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Correção: inicializa string

        public List<CidadeDestino> Cidades { get; set; } = new List<CidadeDestino>();
    }
}
