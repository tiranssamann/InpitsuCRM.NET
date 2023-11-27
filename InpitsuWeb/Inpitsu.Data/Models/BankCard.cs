using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class BankCard
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? RealPan { get; set; }
        public List<Account>? Account { get; set; }
        public Contragent? Contragent { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateActivate { get; set; }
        public DateTime? DateExp { get; set; }
        public TypeCard? TypeCard { get; set; }
        public TypePaySystem? TypePaySystem { get; set; }
        public Status? Status { get; set; } 
    }
    
    
}
