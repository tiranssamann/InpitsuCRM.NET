
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.DtoObjects
{
    public record UserWithRolesDto(
        string Id,
        string UserName,
        string Email,
        string PhoneNumber,
        IList<string> IdentityRoles,
        bool LockoutEnabled,
        bool Locked
    );
}
