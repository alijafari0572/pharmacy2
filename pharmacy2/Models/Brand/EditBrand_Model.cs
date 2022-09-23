using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace pharmacy2.Models.Brand
{
    public class EditBrand_Model
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string En_Name { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Country { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string En_Country { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [Column(TypeName = "ntext")]
        public string Introduction { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public IFormFile Pic { get; set; }
    }
}
