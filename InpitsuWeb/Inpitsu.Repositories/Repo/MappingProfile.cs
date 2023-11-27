using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inpitsu.Data.Models;
using Inpitsu.Data.DtoObjects;
namespace Inpitsu.Repositories.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Attach, AttachDto>();
            CreateMap<AttachCreateDto, Attach>();
            CreateMap<AttachUpdateDto, Attach>();

            CreateMap<Process, ProcessDto>();
            CreateMap<ProcessCreateDto, Process>();
            CreateMap<ProcessUpdateDto, Process>();

            CreateMap<Contragent, ContragentDto>();
            
        }
    }
}
