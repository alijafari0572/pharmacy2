using System;
using System.Collections.Generic;
using System.Text;
using  DAL;
using BE;

namespace BLL
{
    public class BLL_Order
    {
        public void create(Order order)
        {
            DAL_Order dal_Order = new DAL_Order();
             dal_Order.create(order);
        }
        public void updatefinal(Order order ,int refid)
        {
            DAL_Order dal_Order = new DAL_Order();
            dal_Order.updatefinal(order,refid);
        }
        public List<Order> OrderList()
        {
            DAL_Order c = new DAL_Order();
            return c.OrderList();
        }
        public List<Order> OrderListForUser(int Id)
        {
            DAL_Order c = new DAL_Order();
            return c.OrderListForUser(Id);
        }
        public List<Order> getskip(int c)
        {
            DAL_Order dal_Order = new DAL_Order();
            return dal_Order.getskip(c);
        }
        public List<Order> read()
        {
            DAL_Order dal_Order = new DAL_Order();
            return dal_Order.read();
        }
        public Order searchById(int id)
        {
            DAL_Order dal_Order = new DAL_Order();
            return dal_Order.searchById(id);
        }
    }
}
