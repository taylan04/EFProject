using System.ComponentModel.DataAnnotations;

namespace ATCSHARP.Models {
    public class Cliente {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome precisa ter pelo menos 3 letras.")]
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; } = new();
    }
}
