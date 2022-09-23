using Microsoft.AspNetCore.Mvc;
using System;

namespace pharmacy2.Viewcomponents.user
{
    public class PopularDragsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("_PopularDrags");
        }

    }
}
