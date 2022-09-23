using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BE
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderId { get; set; }
        public int DragId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public Order Order { get; set; }
        public Drag Drag { get; set; }

    }
}
