using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Drag_Category
    {
        public int DragId { get; set; }
        public Drag Drag { get; set; }
        public int CategoryId { get; set; }
        public Category  Catagory{ get; set; }
    }
}
