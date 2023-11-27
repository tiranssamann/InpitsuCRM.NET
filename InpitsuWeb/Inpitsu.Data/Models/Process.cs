using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Process
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public User? Author { get; set; }
        public DateTime? Created { get; set; }
        public long? Published { get; set; }
        public long? Current { get; set; }
    }
}
