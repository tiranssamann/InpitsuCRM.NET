using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string? NameContract { get; set; }
        public string? DateContract { get; set; }
        public Contragent? Contragent { get; set; }
    }
}
