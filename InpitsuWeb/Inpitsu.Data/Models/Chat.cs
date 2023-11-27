
namespace Inpitsu.Data.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public User? FromUser { get; set; }
        public User? ToUser { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
