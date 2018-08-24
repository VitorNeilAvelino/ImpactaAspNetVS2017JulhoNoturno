using System.ComponentModel.DataAnnotations;

namespace AspNetVS2017.Capitulo03.Portfolio.Models
{
    public class ContatoViewModel
    {
        [Required(ErrorMessage ="O campo Tal é mais do que obrigatório!")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        //[IdadeMinima]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}