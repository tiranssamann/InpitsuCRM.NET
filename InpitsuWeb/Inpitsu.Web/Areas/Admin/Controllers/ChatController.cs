using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inpitsu.Repositories.Data;
using Inpitsu.Web.ViewModels;
using Inpitsu.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Inpitsu.Web.Areas.Admins.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public ChatController(UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var chats = _dbContext.Chat.Where(c => c.ToUser == null).ToList();
            ChatViewModel viewModel = new ChatViewModel()
            {
                Users = users,
                Chats = chats
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Index(string id)
        {
            return View(GetView(id));
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(string id, string message)
        {
            var currentUser = User.Identity.Name;
            await _dbContext.Chat.AddAsync(new Chat()
            {
                FromUser = _userManager.Users.Where(c => c.UserName == currentUser).FirstOrDefault(),
                ToUser = _userManager.Users.Where(c => c.Id == id).FirstOrDefault(),
                CreatedAt = DateTime.Now,
                Message = message
            });
            await _dbContext.SaveChangesAsync();
            return View("Index", GetView(id));
        }

        ChatViewModel GetView(string id)
        {
            var currentUser = User.Identity.Name;
            var users = _userManager.Users.ToList();
            var chats = _dbContext.Chat.Where(c => (c.ToUser.Id == id && c.FromUser.UserName == currentUser) || (c.ToUser.UserName == currentUser && c.FromUser.Id == id)).OrderBy(c => c.CreatedAt).ToList();
            var selectedUser = users.Where(c => c.Id == id).FirstOrDefault();
            ChatViewModel viewModel = new ChatViewModel()
            {
                Users = users,
                Chats = chats
            };
            if (selectedUser != null)
            {
                viewModel.SelectedUserId = selectedUser.Id;
                viewModel.SelectedUser = selectedUser;
            }
            return viewModel;
        }

    }
    
}
