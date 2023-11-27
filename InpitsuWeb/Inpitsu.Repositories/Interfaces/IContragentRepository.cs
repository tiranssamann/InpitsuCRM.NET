using Inpitsu.Data.Models;
using Inpitsu.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Repositories.Interfaces
{
    public interface IContragentRepository
    {
        public IEnumerable<Contragent> GetAll(bool trackChanges, PaginationFilter validFilter);
        public Contragent GetContragent(Guid id, bool trackChanges);
        public void CreateContragent(Contragent fieldSetting);
        public int GetCount(bool trackChanges);
        public void DeleteContragent(Contragent process);
        public void UpdateContragent(Contragent Process);
    }
}
