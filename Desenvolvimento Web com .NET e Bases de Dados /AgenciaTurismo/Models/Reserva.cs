using System;

namespace AgenciaTurismo.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; } // Correção: torna anulável

        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico? PacoteTuristico { get; set; } // Correção: torna anulável

        public DateTime DataReserva { get; set; }
    }
}
