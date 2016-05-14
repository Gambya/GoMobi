using GoMobi.Api.Domain.Entities;

namespace GoMobi.Api.Domain.ValueObject
{
    public class Tipo : EntityBase
    {
        public string Descricao { get; set; }
        public Photo Icon { get; set; }

    }
}