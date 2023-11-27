using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Currency
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }   
        public int? ISOCode { get; set; }
        public string? ISOCodeAlpha { get; set; }
        public string? Code { get; set; }
    }
}
