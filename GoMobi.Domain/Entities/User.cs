using GoMobi.Domain.Object_Values;

namespace GoMobi.Domain.Entities
{
    public class User : EntityBase
    {
        public string Usuario { get; set; }
        public Email Email { get; set; }
    }
}