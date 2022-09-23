using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL.Migrations;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DAL_Order
    {
        public void create(Order order)
        {
            DB db = new DB();
          // db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.AspNetUsers ON;");
            db.Orders.Add(order);
            db.SaveChanges();
           // db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.AspNetUsers OFF;");
        }
        public List<Order> OrderList()
        {
            DB db = new DB();
            var q = from i in db.Orders select i;
            return q.ToList();
        }
        public List<Order> OrderListForUser(int Id)
        {
            DB db = new DB();
            var q = from i in db.Orders 
                where i.UserId==Id 
                select i;
            return q.ToList();
        }

        public void updatefinal(Order order,int refid)
        {
            DB db = new DB();
            var q = (from i in db.Orders where i.Id == order.Id select i).Single();
            q.IsFinaly = true;
            q.RefId = refid;
            db.SaveChanges();
        }
        public List<Order> getskip(int c)
        {
            int t = c * 10;
            DB db = new DB();
            var q = db.Orders.Skip(t).Take(10);
            return q.ToList();
        }

        public List<Order> read()
        {
            DB db = new DB();
            return db.Orders.ToList();
        }

        
        public Order searchById(int id)
        {
            DB db = new DB();
            var q = from i in db.Orders
                    where i.Id == id
                    select i;
            return q.Single();
        }

        


    }
}
