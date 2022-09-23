using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace pharmacy2.Models.Order
{
    public class OrderList_Model
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public int TotalPrice { get; set; }
        public int RefId { get; set; }
        public bool IsFinaly { get; set; }
        public DateTime CreateDate { get; set; }
        public string Address { get; set; }
    }
}
