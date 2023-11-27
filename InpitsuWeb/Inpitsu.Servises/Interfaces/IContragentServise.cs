using Inpitsu.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inpitsu.Data.DtoObjects;
namespace Inpitsu.Servises.Interfaces
{
    public interface IContragentServise
    {
        IEnumerable<ContragentDto> GetAll(bool trackChanges, PaginationFilter filter);
        ContragentDto GetContragent(Guid Id, bool trackChanges);
        ContragentDto CreateContragent(ContragentCreateDto process);
        void DeleteContragent(Guid Id, bool trackChanges);
        void UpdateContragent(ContragentUpdateDto process);
        public int GetContragentCount(bool trackChanges);
    }
}
