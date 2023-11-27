using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inpitsu.Repositories.Data;
using Inpitsu.Web.ViewModels;
using Inpitsu.Data.Models;

namespace Inpitsu.Web.Areas.Admins.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TasksController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        public IActionResult Details(int id)
        {
            var TEST = dbContext.Tasks.Where(C=>C.Id == id).ToList();
            var task = this.dbContext
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName,
                    Employee = t.Employee.UserName
                })
                .FirstOrDefault();


            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public IActionResult Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards(),
                Employees = GetUsers()
            };

            return View(taskModel);
        }
        public IEnumerable<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }
        
        [HttpPost]
        public IActionResult Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }


            string currentUserId = GetUserId();
            Inpitsu.Data.Models.Task task = new Inpitsu.Data.Models.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId,
                EmployeeId = taskModel.EmployeeId
            };
            this.dbContext.Tasks.Add(task);
            this.dbContext.SaveChanges();

            var boards = this.dbContext.Boards;

            return RedirectToAction("All", "Boards");
        }

        public IActionResult Edit(int id)
        {
            Inpitsu.Data.Models.Task task = dbContext.Tasks.Find(id);
            if (task == null)
            {
                // When task with this id doesn't exist
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                // When current user is not an owner
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards(),
                Employees = GetUsers()
            };
            
            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, TaskFormModel taskModel)
        {
            Inpitsu.Data.Models.Task task = dbContext.Tasks.Find(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                // Not an owner -> return "Unauthorized"
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;
            if (!string.IsNullOrEmpty(taskModel.EmployeeId))
            {
                task.EmployeeId = taskModel.EmployeeId;
            }
            this.dbContext.SaveChanges();
            return RedirectToAction("All", "Boards");
        }

        public IActionResult Delete(int id)
        {
            Inpitsu.Data.Models.Task task = dbContext.Tasks.Find(id);
            if (task == null)
            {
                // When task with this id doesn't exist
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                // When current user is not an owner
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Delete(TaskViewModel taskModel)
        {
            Inpitsu.Data.Models.Task task = dbContext.Tasks.Find(taskModel.Id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                // Not an owner -> return "Unauthorized"
                return Unauthorized();
            }

            this.dbContext.Tasks.Remove(task);
            this.dbContext.SaveChanges();
            return RedirectToAction("All", "Boards");
        }

        public IActionResult Search()
        {
            return View(new TaskSearchFormModel());
        }

        [HttpPost]
        public IActionResult Search(TaskSearchFormModel model)
        {

            var tasks = this.dbContext
                .Tasks
                .Select(t => new TaskViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName
                });

            var keyword = model.Keyword == null ? string.Empty : model.Keyword.Trim().ToLower();
            if (!String.IsNullOrEmpty(keyword) && !String.IsNullOrEmpty(keyword))
            {
                tasks = tasks
                .Where(t => t.Title.ToLower().Contains(keyword)
                    || t.Description.ToLower().Contains(keyword));
            }

            model.Tasks = tasks;

            return View(model);
        }

        private IEnumerable<TaskBoardModel> GetBoards()
            => this.dbContext
                .Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name
                });

        private string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
