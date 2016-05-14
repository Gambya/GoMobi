using GoMobi.Api.Domain.ValueObject;

namespace GoMobi.Api.Domain.Entities
{
    public class User : EntityBase
    {
        public string Nome { get; set; }
        public Email Email { get; set; } 
    }
}