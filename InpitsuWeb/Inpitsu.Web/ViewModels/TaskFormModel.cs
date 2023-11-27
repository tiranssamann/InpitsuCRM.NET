using Inpitsu.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inpitsu.Web.ViewModels
{
    using static DataConstants;
    public class TaskFormModel
    {
        [Required]
        [StringLength(MaxTaskTitle, MinimumLength = MinTaskTitle,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxTaskDescription, MinimumLength = MinTaskDescription, 
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; }

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; }

        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }

        public IEnumerable<User> Employees { get; set; }
    }
}
