using System.ComponentModel.DataAnnotations;

namespace TesteUPD8.Models.ViewModel
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required]
        public Endereco Endereco { get; set; }
    }
}
