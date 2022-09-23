using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BE;
using Microsoft.AspNetCore.Http;
namespace pharmacy2.Models
{
    public class EditDragView_Model
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Name { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string En_Name { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [Column(TypeName = "ntext")]
        public string Introduction { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public int Price { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public int Off_Price_Perset { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public int Off_Price { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Pro_Date { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Exp_Date { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public int Number { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public int MaxOrder { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public int MinOrder { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [Column(TypeName = "ntext")]
        public string Detaile { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [Column(TypeName = "ntext")]
        public string More_Detaile { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public IList<BE.Category> Categorys { get; set; } = new List<Category>();

        public List<int> CategoryIds { get; set; } = new List<int>();
        public IFormFile Pic { get; set; }

        //[Required(ErrorMessage = "عکس ها را وارد  کنید")]
        //[Display(Name = "عکس های محصول")]
        //public List<string> ImagesList { get; set; }

        //[Display(Name = "ویژگی های محصول")]
        //public List<string> Properties { get; set; }
        //    = new List<string>();

        //[Display(Name = "کلمات کلیدی")]
        //public string Tags { get; set; }
    }
}
