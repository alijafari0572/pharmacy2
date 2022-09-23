using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pharmacy2.Models
{
    public class Login_Model
    {
        [Required, Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required, Display(Name = "رمز عبور")]
        public string Password { get; set; }
        public string ReturnURL { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}