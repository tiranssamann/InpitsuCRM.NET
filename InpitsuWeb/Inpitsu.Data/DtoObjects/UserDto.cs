using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.DtoObjects
{
    public record UserCreateDto(Guid Id, string Username, string Password, string Email);
    public record UserUpdateDto(Guid Id, string Username, string Password, string Email);
    public record UserDeleteDto(Guid Id);
}
