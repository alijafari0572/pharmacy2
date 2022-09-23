
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BE
{
    public class Drag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string En_Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Introduction { get; set; }
        public int Price { get; set; }
        public int Off_Price_Perset { get; set; }
        public int Off_Price { get; set; }
        public string Pro_Date { get; set; }
        public string Exp_Date { get; set; }
        public int Number { get; set; }
        public string Pic { get; set; }
        public int MaxOrder { get; set; }
        public int MinOrder { get; set; }
        public int Weight { get; set; }

        [Column(TypeName = "ntext")]
        public string Detaile { get; set; }
        [Column(TypeName = "ntext")]
        public string More_Detaile { get; set; }
        public ICollection<Drag_Category> DragCategories { get; set; } = new List<Drag_Category>(); 
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        //public List<string> ImagesList { get; set; }
        //public List<string> Properties { get; set; }
        //public string Tags { get; set; }
    }
}