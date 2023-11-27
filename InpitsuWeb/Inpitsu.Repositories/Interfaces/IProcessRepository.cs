using Inpitsu.Data.Models;
using Inpitsu.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Repositories.Interfaces
{
    public interface IProcessRepository
    {
        public IEnumerable<Process> GetAll(bool trackChanges, PaginationFilter validFilter);
        public Process GetProcess(Guid id, bool trackChanges);
        public void CreateProcessSetting(Process fieldSetting);
        public int GetCount(bool trackChanges);
        public void DeleteProcess(Process process);
        public void UpdateProcess(Process Process);
    }
}
