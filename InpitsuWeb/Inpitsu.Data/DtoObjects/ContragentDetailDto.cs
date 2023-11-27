
using Org.BouncyCastle.Crypto.Generators;
using System.Text.RegularExpressions;
namespace Inpitsu.Data.DtoObjects
{
    public record ContragentDetailDto
    {
        public ContragentDetailDto() { }
        public ContragentDetailDto(string Id, string Name, string BirthDate, string Phone,
            string DocumentType, string DocumentSeries, string DocumentNumber, string DocumentIssued, string DocumentIssueDate,
            string DocumentEndDate, string GivenPlace, string PIN, string BirthCountry, string BirthPlace, string Nationality, string Rezident)
        {
            this.Id = Id;
            this.Name = Name;
            this.BirthDate = BirthDate;
            this.Phone = Phone;
            this.DocumentType = DocumentType;
            this.DocumentSeries = DocumentSeries;
            this.DocumentNumber = DocumentNumber;
            this.DocumentIssued = DocumentIssued;
            this.DocumentIssueDate = DocumentIssueDate;
            this.DocumentEndDate = DocumentEndDate;
            this.GivenPlace = GivenPlace;
            this.PIN = PIN;
            this.BirthCountry = BirthCountry;
            this.BirthPlace = BirthPlace;
            this.Nationality = Nationality;
            this.Rezident = Rezident;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string DocumentType { get; set; }
        public string DocumentSeries { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentIssued { get; set; }
        public string DocumentIssueDate { get; set; }
        public string DocumentEndDate { get; set; }
        public string GivenPlace { get; set; }
        public string PIN { get; set; }
        public string BirthCountry { get; set; }
        public string BirthPlace { get; set; }
        public string Nationality { get; set; }
        public string Rezident { get; set; }

    }

    public record ContragentCodeWordDto
    {
        private string _codeWord;
        public ContragentCodeWordDto(string CodeWord)
        {

            this._codeWord = CodeWord;

        }
        
    }
}
