using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class BLL_OrderDetail
    {
        public void create(OrderDetail orderdetail)
        {
            DAL_OrderDetail dal_OrderDetail = new DAL_OrderDetail();
            dal_OrderDetail.create(orderdetail);
        }
        public List<OrderDetail> OrderDetail (int orderId)
        {
            DAL_OrderDetail dal_OrderDetail = new DAL_OrderDetail();
            return dal_OrderDetail.OrderDetail(orderId);
        }
    }
}
