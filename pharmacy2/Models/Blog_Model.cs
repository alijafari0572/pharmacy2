using System.ComponentModel.DataAnnotations.Schema;

namespace pharmacy2.Models
{
    public class Blog_Model
    {
        public string Writer { get; set; }
        public string Date { get; set; }
        public string Titel { get; set; }
        [Column(TypeName = "ntext")]
        public string Text { get; set; }
    }
}
