using System.ComponentModel.DataAnnotations;

namespace ATCSHARP.Models {
    public class CidadeDestino {

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por acaso existe cidade sem país?")]
        public int PaisDestinoId { get; set; }
        public PaisDestino PaisDestino { get; set; }
    }
}
