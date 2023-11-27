using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Attach
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Created { get; set; }
        public string? Size { get; set; }
        public string? Location { get; set; }
    }
}
