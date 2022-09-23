using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace pharmacy2.Models
{
    public class Banner_Model
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Name { get; set; }
        //public bool State { get; set; }

        [Required(ErrorMessage = "عنوان H4 را وارد کنید")]
        public string H4 { get; set; }

        [Required(ErrorMessage = "عنوان H3 را وارد کنید")]
        public string H3 { get; set; }
        [Required(ErrorMessage = "عنوان دارو را وارد کنید")]
        public int DragId { get; set; }
        public IFormFile Image { get; set; }
    }
}