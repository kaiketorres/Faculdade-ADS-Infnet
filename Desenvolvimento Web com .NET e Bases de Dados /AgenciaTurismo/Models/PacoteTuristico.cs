using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do pacote é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O título deve ter entre 5 e 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de fim é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
        [Range(1, 1000, ErrorMessage = "A capacidade deve ser entre 1 e 1000 participantes.")]
        [Display(Name = "Capacidade Máxima")]
        public int CapacidadeMaxima { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 100000.00, ErrorMessage = "O preço deve ser maior que zero.")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        // Propriedade para exclusão lógica
        [Display(Name = "Excluído Logicamentee")]
        public bool IsDeleted { get; set; } = false; // Valor padrão como falso

        public List<CidadeDestino> CidadesDestino { get; set; } = new List<CidadeDestino>();
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public int ParticipantesAtuais => Reservas.Count;
        public bool TemVagasDisponiveis => ParticipantesAtuais < CapacidadeMaxima;
        public bool EhFuturo => DataInicio > DateTime.Today;

        public delegate void CapacityReachedEventHandler(PacoteTuristico pacote);
        public event CapacityReachedEventHandler? CapacityReached;

        public void AdicionarReservaSimulada(Reserva novaReserva)
        {
            if (EhFuturo && TemVagasDisponiveis)
            {
                Reservas.Add(novaReserva);
                if (ParticipantesAtuais >= CapacidadeMaxima)
                {
                    CapacityReached?.Invoke(this);
                }
            }
        }
    }
}
