using Inpitsu.Data.Models;

namespace Inpitsu.Web.ViewModels
{
    public class ReleaseDrugsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Contragent? Contragent { get; set; }
        public List<Contragent> Contragents { get; set; }
        public Guid ContragentId { get; set; }
        public List<ReleaseDrugItem>? DrugList { get; set; }
        public List<Drug>? DrugListAll { get; set; }
        public int DrugId { get; set; }
        public int Counts { get; set; }
    }
}
