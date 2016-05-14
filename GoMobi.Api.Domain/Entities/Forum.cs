using GoMobi.Api.Domain.ValueObject;

namespace GoMobi.Api.Domain.Entities
{
    public class Forum
    {
        public User User { get; set; }
        public Message Type { get; set; } 
    }
}