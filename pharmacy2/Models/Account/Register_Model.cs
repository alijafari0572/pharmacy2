using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pharmacy2.Models
{
    public class Register_Model
    {
        [Required]
        [Display(Name = "نام کاربری")]
        [Remote("IsUserInUse", "Account")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        [Remote("IsEmailInUse", "Account")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}