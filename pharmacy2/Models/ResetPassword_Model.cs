using System.ComponentModel.DataAnnotations;

namespace pharmacy2.Models
{
    public class ResetPassword_Model
    {
        [Required]
        [Display(Name = "رمزعبور")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "تکرار رمزعبور")]
        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
