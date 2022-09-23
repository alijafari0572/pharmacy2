using System;
using BE;
using BLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace pharmacy2.Controllers
{
    public class BannerController : Controller
    {
        private IWebHostEnvironment Environment;

        public BannerController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        //public IActionResult Index(int Id)
        //{
        //    BLL_Drag bld = new BLL_Drag();
        //    Drag DD = new Drag();
        //    DD = bld.searchById(Id);
        //    return View("User/Index", DD);
        //}

        public IActionResult create()
        {
            BLL_Drag bld = new BLL_Drag();
            ViewBag.DragViewBag = bld.read();
            return View("Admin/Create");
        }

        [HttpPost]
        public void create(Models.Banner_Model banner)
        {
            BLL_Banner blb = new BLL_Banner();
            Banner b = new Banner();
            b.Name = banner.Name;
            b.State = true;
            b.H4 = banner.H4;
            b.H3 = banner.H3;
            b.DragId = banner.DragId;

            fileupload upf = new fileupload(Environment);
            b.Image = upf.Upload_banner(banner.Image);
            blb.create(b);
        }

        //public IActionResult edite(int id)
        //{
        //    BL_Daro bld = new BL_Daro();
        //    Daro d = new Daro();
        //    d = bld.searchById(id);
        //    return View("Admin/EditeDaro", d);
        //}

        //[HttpPost]
        //public void edite(Models.Daro daro)
        //{
        //    BL_Daro bld = new BL_Daro();
        //    BE.Daro d = new BE.Daro();
        //    d.Id = daro.Id;
        //    d.Name = daro.Name;
        //    d.Price = daro.Price;
        //    d.Off_Pric = daro.Off_Pric;
        //    d.Man_Date = daro.Man_Date;
        //    d.Exp_Date = daro.Exp_Date;Com
        //    fileupload upf = new fileupload(Environment);
        //    if (daro.Pic != null)
        //        d.Pic = upf.Upload(daro.Pic);
        //    bld.edite(d);
        //}

        //public IActionResult ListDaroha()
        //{
        //    BL_Daro Bld = new BL_Daro();
        //    return View("Admin/ListDaroha", Bld.getskip(0));
        //}

        //public IActionResult Daroha()
        //{
        //    BL_Daro bld = new BL_Daro();
        //    List<BE.Daro> DD = bld.read();
        //    return View("User/Daroha", DD);
        //}
    }
}