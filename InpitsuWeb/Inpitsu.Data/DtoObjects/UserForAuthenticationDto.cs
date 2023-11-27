﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.DtoObjects
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; init; }
        
        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; init; }
        
        public string IMEI { get; init; }
        public string IpAddress { get; init; }
        public string FirebaseToken { get; init; }
    }

}
