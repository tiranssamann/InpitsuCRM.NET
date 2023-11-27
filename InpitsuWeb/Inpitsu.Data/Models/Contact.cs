using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Contact
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public List<Phones>? Phones { get; set; }
    }
}
