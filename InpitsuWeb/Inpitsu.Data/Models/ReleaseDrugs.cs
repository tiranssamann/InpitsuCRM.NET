using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class ReleaseDrugs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Contragent? Contragent { get; set; }
        public Guid ContragentId { get; set; }
        public List<ReleaseDrugItem>? DrugList { get; set; }
    }
}
