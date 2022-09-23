using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public ICollection<Drag_Category> DragCategories { get; set; }  //collection navigation property
    }
}
