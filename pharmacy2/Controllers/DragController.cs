using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using BE;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using pharmacy2.Models;
using pharmacy2.Models.Drag;

namespace pharmacy2.Controllers
{
    //[Authorize]
    public class DragController : Controller
    {
        private IWebHostEnvironment Environment;

        public DragController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index(int Id)
        {
            dynamic DragBasket = new ExpandoObject();
            BLL_Drag bld = new BLL_Drag();
            Drag DD = new Drag();
            DD = bld.searchById(Id);
            DragBasket.Drag = DD;
            DragBasket.Order_Lisr = null;
            return View("User/Index", DragBasket);
        }

        public IActionResult create()
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            BLL_Brand bllbrand = new BLL_Brand();
            ViewBag.BrandViewBag = bllbrand.Read();
            return View("Admin/Create");
        }

        [HttpPost]
        public void create(Models.CreateDragViewModel drag)
        {
            BLL_Drag dld = new BLL_Drag();
           // BLL_Brand blb = new BLL_Brand();
            Drag d = new Drag();
           // Brand brand = new Brand();
          //  brand = blb.searchById(drag.BrandId);
            d.Name = drag.Name;
            d.En_Name = drag.En_Name;
            d.Introduction = drag.Introduction;
            d.Price = drag.Price;
            d.Off_Price_Perset = drag.Off_Price_Perset;
            d.Off_Price = drag.Off_Price;
            d.Pro_Date = drag.Pro_Date;
            d.Exp_Date = drag.Exp_Date;
            d.Number = drag.Number;
            d.MaxOrder = drag.MaxOrder;
            d.MinOrder = drag.MinOrder;
            d.Weight = drag.Weight;
            d.Detaile = drag.Detaile;
            d.More_Detaile = drag.More_Detaile;
            d.BrandId = drag.BrandId;
            List<int> c= drag.CategoryIds;
            fileupload upf = new fileupload(Environment);
            d.Pic = upf.Upload(drag.Pic,drag.Name);
            dld.create(d,c);


        }

        public IActionResult edit(int id)
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            BLL_Brand bllbrand = new BLL_Brand();
            ViewBag.BrandViewBag = bllbrand.Read();
            BLL_Drag bld = new BLL_Drag();
            Drag d = new Drag();
            d = bld.searchById(id);
            EditDragView_Model D = new EditDragView_Model
            {
                Name = d.Name,
                En_Name = d.En_Name,
                Introduction = d.Introduction,
                Exp_Date = d.Exp_Date,
                Id = d.Id,
                MaxOrder = d.MaxOrder,
                MinOrder = d.MinOrder,
                Off_Price_Perset = d.Off_Price_Perset,
                Off_Price = d.Off_Price,
                Price = d.Price,
                Pro_Date = d.Pro_Date,
                Weight = d.Weight,
                Detaile = d.Detaile,
                More_Detaile = d.More_Detaile,
                CategoryIds = d.DragCategories.Select(a => a.CategoryId).ToList()
            };
            return View("Admin/EditDrag", D);
        }

        [HttpPost]
        public void edit(Models.EditDragView_Model drag)
        {
            BLL_Drag dld = new BLL_Drag();
            Drag d = new Drag();
            d.Id = drag.Id;
            d.Name = drag.Name;
            d.En_Name = drag.En_Name;
            d.Introduction = drag.Introduction;
            d.Price = drag.Price;
            d.Off_Price_Perset = drag.Off_Price_Perset;
            d.Off_Price = drag.Off_Price;
            d.Pro_Date = drag.Pro_Date;
            d.Exp_Date = drag.Exp_Date;
            d.Number = drag.Number;
            d.MaxOrder = drag.MaxOrder;
            d.MinOrder = drag.MinOrder;
            d.Weight = drag.Weight;
            d.Detaile = drag.Detaile;
            d.More_Detaile = drag.More_Detaile;
            List<int> c = drag.CategoryIds;
            fileupload upf = new fileupload(Environment);
            if (drag.Pic!=null)
            {
                d.Pic = upf.Upload(drag.Pic,drag.Name);
            }
            dld.edit(d, c);
        }
        public IActionResult delete(int id)
        {
            BLL_Drag bld = new BLL_Drag();
            BE.Drag d = new BE.Drag();
            bld.delete(id);
            return RedirectToAction("DragsList", "Drag");
        }
        public IActionResult Drags()
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            BLL_Drag bld = new BLL_Drag();
            ViewBag.PageActive = "active";
            //List<BE.Drag> DD = bld.read();
            //return View("User/Drags",DD);
            return View("User/Drags", bld.getskip(0));

        }
        //public IActionResult teacher_list()
        //{
        //    BL_teacher Blt = new BL_teacher();
        //    return View("teacher_list", Blt.getskip(0));
        //}
        public IActionResult getskip(int c)
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            BLL_Drag bld = new BLL_Drag();
            return View("User/Drags", bld.getskip(c));
        }
        public IActionResult DragsList()
        {
            
            BLL_Drag bld = new BLL_Drag();
            List<BE.Drag> DD = bld.read();
            return View("Admin/DragList", DD);
        }
        public IActionResult Search(string q)
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            ViewBag.PageActive = "active";
            BLL_Drag bld = new BLL_Drag();
            List<BE.Drag> draglist = bld.search(q);
            return View("User/SearchResultDrags", draglist);
        }

        public IActionResult MenuClickResult(int Id)
        {
            BLL_Category blc = new BLL_Category();
            ViewBag.CategoryViewBag = blc.read();
            BLL_Drag bld = new BLL_Drag();
            List<BE.Drag> draglist = bld.MenuClickResult(Id);
            var modelcourse = new List<Models.Drag.MenuClickResult_Model>();
            foreach (var item in draglist)
            {
                if (Id == item.DragCategories.Select(s => s.CategoryId).SingleOrDefault())
                {
                    modelcourse.Add(new MenuClickResult_Model()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Detaile = item.Detaile,
                        Price = item.Price,
                        Exp_Date = item.Exp_Date,
                        Off_Price = item.Off_Price,
                        Number = item.Number,
                        MaxOrder = item.MaxOrder,
                        MinOrder = item.MinOrder,
                        Pro_Date = item.Pro_Date,
                        Pic = item.Pic,
                        CategoryId = item.DragCategories.Select(s => s.CategoryId).SingleOrDefault(),
                    });
                }
            }
            return View("User/MenuClickResultDrags", modelcourse);

        }
    }
}