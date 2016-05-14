using System.IO;

namespace GoMobi.Api.Domain.ValueObject
{
    public class Photo
    {
        public string Path { get; set; }
        public string Descricao { get; set; }
        public bool Capa { get; set; }
    }
}