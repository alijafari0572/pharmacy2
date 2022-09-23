using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BE;
using BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using pharmacy2.Models.Order;

namespace pharmacy2.Controllers
{
    public class OrderController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public OrderController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        public IActionResult AddToBasket(int DragId, int Number)
        {
            var basketlist = new List<Order_List>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                basketlist =
                    JsonConvert.DeserializeObject<List<Order_List>>(HttpContext.Session.GetString("basket")).ToList();
                var dragList = basketlist.Select(l => l.DragId).ToList();
                var q = (from i in dragList where dragList.Contains(DragId) select i);
                if (q.Any())
                {
                    foreach (var item in basketlist)
                    {
                        if (item.DragId == DragId)
                        {
                            item.Number = Number;
                        }
                    }
                }
                else
                {
                    basketlist.Add(new Order_List {DragId = DragId, Number = Number});

                }

            }
            else
            {
                basketlist.Add(new Order_List {DragId = DragId, Number = Number});
            }

            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketlist));
            return RedirectToAction("Index", "Drag", new {id = DragId});
        }

        public IActionResult UpdateBasket(int DragId, int Number)
        {
            var basketlist = new List<Order_List>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                basketlist =
                    JsonConvert.DeserializeObject<List<Order_List>>(HttpContext.Session.GetString("basket")).ToList();
                //var itemToUpdate = basketlist.Single(r => r.DragId == DragId);
                //if (itemToUpdate != null) itemToUpdate.Number = Number;
                foreach (Order_List obj in basketlist)
                {
                    if (obj.DragId == DragId)
                    {
                        obj.Number = Number;
                        break;
                    }
                }
            }

            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketlist));
            return RedirectToAction("Basket", "Profile");

        }

        public IActionResult RemoveDragBasket(int DragId)
        {
            var basketlist = new List<Order_List>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                basketlist =
                    JsonConvert.DeserializeObject<List<Order_List>>(HttpContext.Session.GetString("basket")).ToList();
                var itemToRemove = basketlist.Single(r => r.DragId == DragId);
                basketlist.Remove(itemToRemove);
            }

            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketlist));
            return RedirectToAction("Basket", "Profile");
        }

        public async Task<IActionResult> OrderListAsync()
        {
            BLL_Order bllOrder = new BLL_Order();
            List<Order> orders = new List<Order>();
            List<OrderList_Model> orderListModels = new List<OrderList_Model>();
            orders = bllOrder.OrderList();
            foreach (var item in orders)
            {
                var user = await userManager.FindByIdAsync((item.UserId).ToString());
                orderListModels.Add(new OrderList_Model()
                {
                    OrderId = item.Id,
                    UserName = user.UserName,
                    TotalPrice = item.TotalPrice,
                    RefId = item.RefId,
                    IsFinaly = item.IsFinaly,
                    CreateDate = item.CreateDate,
                    Address = item.Address
                });
            }

            return View("Admin/OrderList", orderListModels);
        }

        public IActionResult OrderDetail(int OrderId, string UserName)
        {
            BLL_OrderDetail bllOrderDetail = new BLL_OrderDetail();

            BLL_Drag bld = new BLL_Drag();
            List<BE.OrderDetail> orderDetailslist = bllOrderDetail.OrderDetail(OrderId);
            var modelorderdetail = new List<Models.Order.OrderDetail_Model>();
            foreach (var item in orderDetailslist)
            {
                modelorderdetail.Add(new OrderDetail_Model()
                {
                    UserName = UserName,
                    OrderId = item.OrderId,
                    DragId = item.DragId,
                    DragName = bld.searchById(item.DragId).Name,
                    Count = item.Count,
                    Price = item.Price,
                    TotalPrice = item.Count * item.Price
                });

            }
            return View("Admin/OrderDetail", modelorderdetail);
        }

        public IActionResult OrderDetailUser(int OrderId, string UserName)
        {
            BLL_OrderDetail bllOrderDetail = new BLL_OrderDetail();

            BLL_Drag bld = new BLL_Drag();
            List<BE.OrderDetail> orderDetailslist = bllOrderDetail.OrderDetail(OrderId);
            var modelorderdetail = new List<Models.Order.OrderDetail_Model>();
            foreach (var item in orderDetailslist)
            {
                modelorderdetail.Add(new OrderDetail_Model()
                {
                    UserName = UserName,
                    OrderId = item.OrderId,
                    DragId = item.DragId,
                    DragName = bld.searchById(item.DragId).Name,
                    DragPic = bld.searchById(item.DragId).Pic,
                    Count = item.Count,
                    Price = item.Price,
                    TotalPrice = item.Count * item.Price
                });

            }
            return View("User/OrderDetailUser", modelorderdetail);
        }

    }
}
