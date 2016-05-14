using System.Collections.Generic;
using GoMobi.Domain.Object_Values;

namespace GoMobi.Domain.Entities
{
    public class Acessibilidade : EntityBase
    {
        public TipoAcessibilidade TipoAcessibilidade { get; set; }
        public string Description { get; set; }
        public List<Photo> Photos { get; set; }
        public User User { get; set; }
    }
}