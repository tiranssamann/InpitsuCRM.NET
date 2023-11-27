using Inpitsu.Data.Models;

namespace Inpitsu.Web.ViewModels
{
    public class ChatViewModel
    {
        public string? SelectedUserId { get; set; }
        public User? SelectedUser { get; set; }
        public List<User>? Users { get; set; }
        public List<Chat>? Chats { get; set; }

        public string DefaultAvatar { get { return "https://images.vexels.com/media/users/3/129616/isolated/preview/fb517f8913bd99cd48ef00facb4a67c0-businessman-avatar-silhouette-by-vexels.png"; } }
    }
}
