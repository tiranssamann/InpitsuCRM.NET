using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Contragent
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public long? Pin { get; set; }
        public long? Inn { get; set; }
        public string? Email { get; set; }
        public List<Contract>? Contracts { get; set; }
        public List<Account>? Accounts { get; set; }
        public List<BankCard>? BankCards { get; set; }
    }
}
