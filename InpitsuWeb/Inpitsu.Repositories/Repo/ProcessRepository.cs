using Inpitsu.Data.Models;
using Inpitsu.Filters;
using Inpitsu.Repositories.Data;
using Inpitsu.Repositories.Interfaces;

namespace Inpitsu.Repositories.Repo
{
    public class ProcessRepository : RepositoryBase<Process>, IProcessRepository
    {
        public ProcessRepository(ApplicationDbContext repositoryContext)
           : base(repositoryContext)
        {
        }
        public void DeleteProcess(Process process)
        {
            Delete(process);
        }
        public void CreateProcessSetting(Process fieldSetting)
        {
            Create(fieldSetting);
        }
        public int GetCount(bool trackChanges)
        {
            return FindAll(trackChanges).Count();
        }

        public Process GetProcess(Guid id, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
        }

        public IEnumerable<Process> GetAll(bool trackChanges, PaginationFilter validFilter)
        {
            return FindAll(trackChanges)
                .OrderBy(p => p.Id)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();
        }

        public void UpdateProcess(Process Process)
        {
            Update(Process);
        }
    }
}
