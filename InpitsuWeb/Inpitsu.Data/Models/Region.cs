using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Region
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public long? Code { get; set; }
    }
}
