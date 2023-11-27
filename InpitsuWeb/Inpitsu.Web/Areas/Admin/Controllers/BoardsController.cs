using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inpitsu.Repositories.Data;
using Inpitsu.Web.ViewModels;
using Inpitsu.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Inpitsu.Web.Areas.Admins.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BoardsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public BoardsController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [Route("/{controller}")]
        public IActionResult All()
        {
            var boards = this.dbContext.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName,
                        Employee = t.Employee.UserName
                        
                    })
                })
                .ToList();

            return View(boards);
        }
        public IActionResult Create()
        {  
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm]BoardViewModel BoardModel)
        {
            
            Board task = new Board()
            {
                Name = BoardModel.Name,
            };
            this.dbContext.Boards.Add(task);
            this.dbContext.SaveChanges();

            return RedirectToAction("GetAllBoards", "Boards");
        }
        public RedirectToActionResult Cansel()
        {
            return RedirectToAction("All");
        }
        public IActionResult GetAllBoards()
        {

            var a = this.dbContext.Boards.ToList();
            BoardViewModels viewModels = new BoardViewModels() 
            {
                boards = a
            };


            return View(a);
        }
        
    }
    public class BoardViewModels
    {
        public List<Board>? boards;
    }
}
