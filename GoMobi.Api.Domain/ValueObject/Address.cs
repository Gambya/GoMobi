using System.Security.Cryptography;

namespace GoMobi.Api.Domain.ValueObject
{
    public class Address
    {
        public string Logradouro { get; set; } 
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Cep Cep { get; set; }
        public Estado Estado { get; set; }
    }
}