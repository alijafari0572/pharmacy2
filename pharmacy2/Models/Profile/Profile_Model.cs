using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace pharmacy2.Models.Profile
{
    public class Profile_Model
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "نام ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "نام استان")]
        public string Province { get; set; }
        [Required]
        [Display(Name = "نام شهر")]
        public string City { get; set; }
        [Required]
        [Display(Name = "نام آدرس")]
        public string Address { get; set; }
    }
}
