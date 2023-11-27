using Inpitsu.Data.Models;

namespace Inpitsu.Web.ViewModels
{
    public class ChatViewUsers
    {
        public List<User> Users { get; set; }
        public User Sender { get; set; }
        public User ThisUser { get; set; }
    }
}
