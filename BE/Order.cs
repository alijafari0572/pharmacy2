using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BE
{
    public class Order
    {
        //region Fields
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int RefId { get; set; }
        public bool IsFinaly { get; set; }
        public DateTime CreateDate { get; set; }
        public string Address{ get; set; }
        //region Relations
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
       

    }
}

