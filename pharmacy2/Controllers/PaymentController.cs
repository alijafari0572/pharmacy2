using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE;
using BLL;
using DAL.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zarinpal;


namespace pharmacy2.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private UserManager<User> userManager;

        public PaymentController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Payment()
        {
            var DragIds = new List<Order_List>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                DragIds = JsonConvert.DeserializeObject<List<Order_List>>(HttpContext.Session.GetString("basket"));

                var bld = new BLL_Drag();
                var Drags = bld.SearchByListId(DragIds);

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var SUM = 0;
                foreach (var Drag in Drags)
                {
                    foreach (var item in DragIds)
                    {
                        if (Drag.Id == item.DragId)
                        {
                            SUM = SUM + Drag.Price * item.Number;
                        }
                    }
                }

                if (user.Province == "خراسان رضوی")
                {
                    SUM = SUM + 25000;
                }
                else
                {
                 SUM = SUM + 35000;
                }
                BLL_Order bll_order = new BLL_Order();
                var order = new Order
                {
                    TotalPrice = SUM,
                    UserId = user.Id,
                    Address = user.Address,
                    CreateDate = DateTime.Now
                };
                bll_order.create(order);
                BLL_OrderDetail bll_OrderDetail = new BLL_OrderDetail();
                foreach (var item in DragIds)
                {
                    var drag = bld.searchById(item.DragId);
                    OrderDetail Orderdetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        DragId = item.DragId,
                        Count = item.Number,
                        Price = drag.Price

                    };
                    bll_OrderDetail.create(Orderdetail);
                }

                
                var payment = new Payment("b927531b-2883-4656-97ce-5a24fb508041", order.TotalPrice);
                var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.Id}",
                    "https://wikidaroo.net/Home/OnlinePayment/" + order.Id, user.Email,user.PhoneNumber);
                if (res.Result.Status == 100)
                {
                    return Redirect("https://zarinpal.com/pg/StartPay/" + res.Result.Authority);
                }
                else
                {
                    return RedirectToAction("PaymentError", "profile");
                }

                //return View("Index","Home");
            }
            return View("Index","Home");


        }
    }
}