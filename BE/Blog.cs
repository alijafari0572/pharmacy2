using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BE
{
    public class Blog
    {
        public int Id { get; set; }
        public string Writer { get; set; }
        public string Date { get; set; }
        public string Titel { get; set; }
        [Column(TypeName = "ntext")]
        public string Text { get; set; }
    }
}
