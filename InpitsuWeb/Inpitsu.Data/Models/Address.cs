using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Address
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public Region? Region { get; set; }
        public Country? Country { get; set; }
        public District? District { get; set; }
    }
}
