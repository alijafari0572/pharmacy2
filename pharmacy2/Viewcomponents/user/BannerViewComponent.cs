using BLL;
using Microsoft.AspNetCore.Mvc;

namespace pharmacy.Viewcomponents.user
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL_Banner blb = new BLL_Banner();
            return View("_Banner", blb.read());
        }
    }
}