using Microsoft.AspNetCore.SignalR;

namespace Inpitsu.Web.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string UserName, string Message)
        {
            await Clients.All.SendAsync("ReceivedMessage", UserName, Message);
        }
        public Task SendMessageToGroup(string sender, string receiver, string message)
        {
            return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
        }
    }
}
