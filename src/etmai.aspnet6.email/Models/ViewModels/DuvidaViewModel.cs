using System.ComponentModel.DataAnnotations;

namespace etmai.aspnet6.email.Models.ViewModels
{
    public class DuvidaViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        public string? Telefone { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string TipoServico { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 100)]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Notificar { get; set; }

        public DateTime Date = DateTime.UtcNow;
    }
}
