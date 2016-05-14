using System.Collections.Generic;
using GoMobi.Api.Domain.ValueObject;

namespace GoMobi.Api.Domain.Entities
{
    public class Acessibilidade : EntityBase
    {
        public User User { get; set; }
        public Tipo Tipo { get; set; }
        public Address Endereco { get; set; }
        public double BordaSuperior { get; set; }
        public double BordaEsquerda { get; set; }
        public double BordaDireita { get; set; }
        public double BordaInferior { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Photo> Photos { get; set; }
    }
}