using Microsoft.AspNetCore.Mvc;

namespace pharmacy2.Viewcomponents.user
{
    public class BlogViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("_Blog");
        }
    }
}
