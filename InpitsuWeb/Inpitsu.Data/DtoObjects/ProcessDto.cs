using Inpitsu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.DtoObjects
{
    public record ProcessDto(Guid Id, string Name, User Author, DateTime Created, DateTime Published, DateTime Current);
    public record ProcessCreateDto(Guid Id, string Name, User Author, DateTime Created, long Published = 0, long Current = 0);
    public record ProcessUpdateDto(Guid Id, string Name, User Author, long Published, long Current);
    public record ProcessDeleteDto(Guid Id);

}
