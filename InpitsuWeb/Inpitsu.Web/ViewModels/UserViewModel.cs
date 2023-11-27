
using Inpitsu.Data.DtoObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Inpitsu.Web.ViewModels
{
    public class UserViewModel
    {
        public UserForRegistrationDto User { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
    }
}
