namespace TesteUPD8.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }


        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public int UFSiglaId { get; set; }

        public UF UFSigla { get; set; }

        public string Cidade { get; set; }


    }
}
