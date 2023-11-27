using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.DtoObjects
{
    public record AttachDto(Guid Id, string Name, DateTime Created, string Size, string Location);
    public record AttachCreateDto(Guid Id, string Name, DateTime Created, string Size, string Location);
    public record AttachUpdateDto(Guid Id, string Name, DateTime Created, string Size, string Location);
    public record AttachDeleteDto(Guid Id);
}
