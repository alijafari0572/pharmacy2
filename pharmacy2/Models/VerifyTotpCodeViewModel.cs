using System.ComponentModel.DataAnnotations;

namespace pharmacy2.Models
{
    public class VerifyTotpCodeViewModel
    {
        [Display(Name = "کد ارسال شده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [MaxLength(6, ErrorMessage = "حداکثر طول مجاز {0} {1} کاراکتر است.")]
        public string TotpCode { get; set; }
    }
}