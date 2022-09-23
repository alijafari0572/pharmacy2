using System.ComponentModel.DataAnnotations;

namespace pharmacy2.Models
{
    public class ForgotPassword_Model
    {
        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }
    }
}