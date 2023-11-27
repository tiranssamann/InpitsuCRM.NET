using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inpitsu.Data.DtoObjects;
using Inpitsu.Filters;
using Inpitsu.Servises.Interfaces;
using Inpitsu.Repositories.Interfaces;
using AutoMapper;
using Inpitsu.Data.Models;
using Inpitsu.Logger;
namespace Inpitsu.Servises.Servises
{
    public class ContragentServise : IContragentServise
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ContragentServise(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public ContragentDto CreateContragent(ContragentCreateDto contragent)
        {
            var contragentEntity = _mapper.Map<Contragent>(contragent);

            _repository.ContragentRepository.CreateContragent(contragentEntity);
            _repository.Save();

            var result = _mapper.Map<ContragentDto>(contragentEntity);

            return result;
        }

        public void DeleteContragent(Guid Id, bool trackChanges)
        {
            var contragents = _repository.ContragentRepository.GetContragent(Id, trackChanges);
            if (contragents is null)
                throw new Exception();

            _repository.ContragentRepository.DeleteContragent(contragents);
            _repository.Save();
        }

        public ContragentDto GetContragent(Guid Id, bool trackChanges)
        {
            var contragent = _repository.ContragentRepository.GetContragent(Id, trackChanges);
            return _mapper.Map<ContragentDto>(contragent);
        }

        public int GetContragentCount(bool trackChanges)
        {
            return _repository.ContragentRepository.GetCount(trackChanges);
        }

        public void UpdateContragent(ContragentUpdateDto contragent)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ContragentDto> GetAll(bool trackChanges, PaginationFilter filter)
        {
            try
            {
                var contragents = _repository.ContragentRepository.GetAll(trackChanges, filter);
                var contragentsDto = _mapper.Map<IEnumerable<ContragentDto>>(contragents);
                return contragentsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} service method {ex}");
                throw;
            }
        }
    }
}
