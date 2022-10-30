using System.ComponentModel.DataAnnotations;

namespace TesteUPD8.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }    
        
        public Sexo Sexo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        public Endereco Endereco { get; set; }



    }
}
