using Inpitsu.Repositories.Data;
using Inpitsu.Repositories.Interfaces;
namespace Inpitsu.Repositories.Repo
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IProcessRepository> _processes;
        private readonly Lazy<IContragentRepository> _contragents;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _processes = new Lazy<IProcessRepository>(() => new ProcessRepository(context));
            _contragents = new Lazy<IContragentRepository>(() => new ContragentRepository(context));

        }
        public IProcessRepository ProcessRepository => _processes.Value;
        public IContragentRepository ContragentRepository => _contragents.Value;
        public void Save() => _context.SaveChanges();
    }
}
