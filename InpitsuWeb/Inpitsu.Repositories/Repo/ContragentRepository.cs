using Inpitsu.Data.Models;
using Inpitsu.Filters;
using Inpitsu.Repositories.Data;
using Inpitsu.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Repositories.Repo
{
    public class ContragentRepository : RepositoryBase<Contragent>, IContragentRepository
    {
        public ContragentRepository(ApplicationDbContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public void CreateContragent(Contragent fieldSetting)
        {
            Create(fieldSetting);
        }

        public void DeleteContragent(Contragent process)
        {
            Delete(process);
        }

        public IEnumerable<Contragent> GetAll(bool trackChanges, PaginationFilter validFilter)
        {
            return FindAll(trackChanges)
                .OrderBy(p => p.Id)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();
        }

        public Contragent GetContragent(Guid id, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
        }

        public int GetCount(bool trackChanges)
        {
            return FindAll(trackChanges).Count();
        }

        public void UpdateContragent(Contragent Process)
        {
            Update(Process);
        }
    }
}
