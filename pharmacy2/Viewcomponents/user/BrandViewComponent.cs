using System.Linq;
using BLL;
using Microsoft.AspNetCore.Mvc;


namespace pharmacy2.Viewcomponents.user
{
    public class BrandViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL_Brand bllBrand = new BLL_Brand();
            return View("_Brand", bllBrand.Read());
        }
    }
}
