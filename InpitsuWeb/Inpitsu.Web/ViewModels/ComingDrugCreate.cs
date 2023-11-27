using Inpitsu.Data.Models;

namespace Inpitsu.Web.ViewModels
{
    public class ComingDrugCreate
    {
        public Guid Id { get; set; }
        public string? NameOfComing { get; set; }
        public List<Contragent>? Contragents { get; set; }
        public string? ContragentId { get; set; }
        public DateTime? DateOfComing { get; set; }
        public string? NameOfDrug { get; set; }
        public int? Counts { get; set; }
        public string? FormCreations { get; set; }
        public double? ComingPrice { get; set; }
        public double? ComingProcent { get; set; }
        public double? Price { get; set; }
        public double Procent { get; set; }
        public DateTime? DateOfExplotation { get; set; }
        public string? Creator { get; set; }
        public string? SNumber { get; set; }
        public ComingDrug? ComingDrug { get; set; }
        public Currency? Currency { get; set; }
        public List<Drug>? Drugss { get; set; }
        
    }
}
