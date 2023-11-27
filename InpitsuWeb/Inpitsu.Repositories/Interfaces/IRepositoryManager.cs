using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IProcessRepository ProcessRepository { get; }
        IContragentRepository ContragentRepository { get; }
        void Save();
    }
}
