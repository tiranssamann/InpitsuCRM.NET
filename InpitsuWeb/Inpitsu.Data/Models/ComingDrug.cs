using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class ComingDrug
    {
        public Guid ID { get; set; }
        public string? NameOfComing { get; set; }
        public Contragent? Contragent { get; set; }
        public DateTime? DateOfComing { get; set; }
        public List<Drug>? Drugss { get; set; }
    }
}
