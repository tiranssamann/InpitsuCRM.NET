using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inpitsu.Data.Models;
using Inpitsu.Logger;
using Inpitsu.Repositories.Interfaces;
using Inpitsu.Servises.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Inpitsu.Servises.Servises
{
    public class ServiseManager : IServiceManager
    {

        private readonly Lazy<IContragentServise> _contragent;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiseManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            


            _contragent = new Lazy<IContragentServise>(() => new ContragentServise(repositoryManager, mapper, logger));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IContragentServise ContragentService => _contragent.Value;
    }
}
