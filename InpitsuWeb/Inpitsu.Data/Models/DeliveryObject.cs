using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class DeliveryObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public Contragent Contragent { get; set; }
        public DateTime DayDelivery { get; set; }
        public StatusDelivery StatusDelivery { get; set; }
    }
}
