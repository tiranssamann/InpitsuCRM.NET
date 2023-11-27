using Inpitsu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Repositories.Interfaces
{
    public interface IAttachRepository
    {
        public List<Attach> GetAttaches();
        public Attach GetAttach(Guid id);
        public int GetCount();
        public void DeleteAttach(Guid id);
        public void UpdateAttach(Attach attach);
    }
}
