using System.Linq;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inpitsu.Repositories.Data;
using Inpitsu.WebAPI.Models.Board;
using Inpitsu.WebAPI.Models.Task;

namespace Inpitsu.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/boards")]
    public class BoardsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BoardsController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        /// <summary>
        /// Gets all boards.
        /// </summary>
        /// <remarks>
        /// You should be an authenticated user!
        /// 
        /// Sample request:
        ///
        ///     GET /api/boards
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with a list of all boards</response>
        /// <response code="401">Returns "Unauthorized" when user is not authenticated</response> 
        [HttpGet]
        public IActionResult GetBoards()
        {
            var boards = this.dbContext
                .Boards
                .Select(b => new BoardListingModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskListingModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description
                    })
                })
                .ToList();

            return Ok(boards);
        }
    }
}
