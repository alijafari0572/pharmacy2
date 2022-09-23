using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DAL_OrderDetail
    {
        public void create(OrderDetail orderdetail)
        {
            DB db = new DB();
            db.OrderDetails.Add(orderdetail);
            db.SaveChanges();
        }

        public List<OrderDetail> OrderDetail(int orderId)
        {
            DB db = new DB();
            List<OrderDetail> orderDetail = new List<OrderDetail>();
            var q = from i in db.OrderDetails
                    .Include(od =>od.Drag)
                    .Include(od=>od.Order)
                where i.OrderId==orderId
                select i;
            orderDetail = q.ToList();
            return orderDetail;

        }
    }
}
