using Inpitsu.Data.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inpitsu.Web.ViewModels
{
    using static DataConstants;
    public class TaskSearchFormModel
    {
        [StringLength(MaxKeyword)]
        public string Keyword { get; init; }

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
