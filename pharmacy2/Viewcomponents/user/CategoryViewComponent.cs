using BLL;
using Microsoft.AspNetCore.Mvc;


namespace pharmacy2.Viewcomponents.user
{
    public class CategoryViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            return View("_Category");
        }
    }
}
