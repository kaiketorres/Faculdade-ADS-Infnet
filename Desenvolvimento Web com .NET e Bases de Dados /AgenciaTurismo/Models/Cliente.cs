using System.ComponentModel.DataAnnotations; // Adicione este using

namespace AgenciaTurismo.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")] // Validação de preenchimento obrigatório
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")] // Validação de comprimento mínimo e máximo
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail do cliente é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do e-mail é inválido.")] // Validação de formato de e-mail
        [StringLength(150, ErrorMessage = "O e-mail não pode exceder 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
