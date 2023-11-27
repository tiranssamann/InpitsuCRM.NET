using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Inpitsu.Data.Models
{
    public class User : IdentityUser
    {
        public bool Locked { get; set; }
    }
}
