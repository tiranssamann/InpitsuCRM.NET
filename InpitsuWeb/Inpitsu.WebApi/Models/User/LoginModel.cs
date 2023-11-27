using System.ComponentModel.DataAnnotations;

namespace Inpitsu.WebAPI.Models.User
{
    public class LoginModel
    {
        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }
    }
}