using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace pharmacy2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            return View("Admin/create");
        }
        [HttpPost]
        public IActionResult create(Models.Catagory_Model Catagory)
        {
            BLL_Category blc = new BLL_Category();
            Category c = new Category();
            c.Name = Catagory.Name;
            c.ParentId = Catagory.ParentId;
            blc.create(c);
            return RedirectToAction("create", "Category");

        }
    }
}
