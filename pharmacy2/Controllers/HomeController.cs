using BLL;
using BE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pharmacy2.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Zarinpal;

namespace pharmacy2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult OnlinePayment(int Id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                BLL_Order bll_order = new BLL_Order();
                var order =  bll_order.searchById(Id);
                var payment = new Payment("b927531b-2883-4656-97ce-5a24fb508041", order.TotalPrice);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    bll_order.updatefinal(order,(int)res.RefId);
                    ViewBag.code = res.RefId;
                    HttpContext.Session.Remove("basket");
                    return View();
                }

            }

            return RedirectToAction("PaymentError", "profile");

        }

    }
}