using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class ApplicationFor
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateAccept { get; set; }
        public long? SumAccept { get; set; }
        public long? SumNeed { get; set; }
        public StatusApplication? StatusApplication { get; set; }
        public List<Attach>? Attach { get; set; }
        public Contragent? Contragent { get; set; }
        public string? CreditTerm { get; set; }
        public string? GrasePeriod { get; set; }
        public string? RejectString { get; set; }
        public int? EmployeeCount { get; set; }
        public int? EmployeeCountWomen { get; set; }
        public int? WorkCreate { get; set; }
        public string? PurposeOfFunding { get; set; }
        public Currency? Currency { get; set; }
    }
}
