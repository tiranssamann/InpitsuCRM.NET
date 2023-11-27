using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inpitsu.Data.Models
{
    using static DataConstants;

    public class Board
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxBoardName)]
        public string? Name { get; init; }

        public IEnumerable<Task>? Tasks { get; set; } = new List<Task>();
    }
}
