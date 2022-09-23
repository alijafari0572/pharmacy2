using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE;
using BLL;
using DAL;
using IdentitySample.Security.PhoneTotp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pharmacy2.Models;
using pharmacy2.Models.Profile;

namespace pharmacy2.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public ProfileController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
             return View();
        }
       public IActionResult Basket()
       {
           return View();
       }
       public async Task<IActionResult> ProfileAsync()
       {
           var user = await userManager.FindByNameAsync(User.Identity.Name);
           var userModel = new Profile_Model();
           BLL_Order blorder = new BLL_Order();
           BLL_Province blprovince = new BLL_Province();
           BLL_City blcity = new BLL_City();
           ViewBag.OrderViewBag = blorder.OrderListForUser( user.Id);
           ViewBag.ProvinceViewBag = blprovince.Read();
           ViewBag.CityViewBag = blcity.Read();

           userModel.UserName = user.UserName;
           userModel.Name = user.Name;
           userModel.LastName = user.LastName;
           userModel.PhoneNumber = user.PhoneNumber;
           userModel.Province = user.Province;
           userModel.City = user.City;
           userModel.Address = user.Address;
           userModel.Email = user.Email;
           return View(userModel);
       }

       public async Task<IActionResult> ChangeProfileAsync(Models.Profile.Profile_Model model)
       {
           BLL_Province blprovince = new BLL_Province();
           BLL_City blcity = new BLL_City();
           Province province = new Province();
           City city = new City();
           province = blprovince.GetCityById(Int32.Parse(model.Province));
           city = blcity.GetCityById(Int32.Parse(model.City));
            var user = await userManager.FindByNameAsync(User.Identity.Name);
           user.Name = model.Name;
           user.LastName = model.LastName;
           user.PhoneNumber = model.PhoneNumber;
           user.Province = province.Name;
           user.City =city.Name;
           user.Address = model.Address;
            var result = await userManager.UpdateAsync(user);
            if(result.Succeeded) return RedirectToAction ("Profile","profile");
            return View(model);
       }
       [HttpPost]
       public IActionResult GetCity(int Id)
       {
           DB db = new DB();
           var cityList = db.Cities.Where(c => c.ProvinceId == Id)
               .Select(c => new { Id = c.Id, cname = c.Name }).ToList();
           return Json(new { status = "success", cityList });
       }

       public IActionResult About()
       {
           return View("About");
       }
       public IActionResult PaymentError()
       {
           return View("PaymentError");
       }
    }
}
