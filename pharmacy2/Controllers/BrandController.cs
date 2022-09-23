using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using BE;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using pharmacy2.Models;
using pharmacy2.Models.Brand;

namespace pharmacy2.Controllers
{
    public class BrandController : Controller
    {
        private IWebHostEnvironment Environment;

        public BrandController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            BLL_Brand blb = new BLL_Brand();
            ViewBag.BrandViewBag = blb.Read();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Models.Brand.CreateBrand_Model brandModel)
        {
            BLL_Brand blbBrand = new BLL_Brand();
            Brand b = new Brand();
            b.Name = brandModel.Name;
            b.En_Name =brandModel.En_Name;
            b.Country = brandModel.Country;
            b.En_Country = brandModel.En_Country;
            b.Introduction = brandModel.Introduction;
            b.Detail = brandModel.Detail;
            fileupload upf = new fileupload(Environment);
            b.Pic = upf.Upload(brandModel.Pic , b.Name);
            blbBrand.Create(b);
            return RedirectToAction("Create", "Brand");
        }

        public IActionResult Edit(int Id)
        {
            BLL_Brand blb = new BLL_Brand();
            ViewBag.BrandViewBag = blb.Read();
            BLL_Brand blbBrand = new BLL_Brand();
            Brand b = new Brand();
            b = blbBrand.SearchById(Id);
            EditBrand_Model brand = new EditBrand_Model()
            {
                Id = Id,
                Name = b.Name,
                En_Name = b.En_Name,
                Country = b.Country,
                En_Country = b.En_Country,
                Introduction = b.Introduction,
                Detail = b.Detail
            };
            return View("Edit", brand);
        }

        [HttpPost]
        public IActionResult Edit(Models.Brand.EditBrand_Model brand)
        {
            BLL_Brand bllbrand = new BLL_Brand();
            Brand b = new Brand();
            b.Id = brand.Id;
            b.Name = brand.Name;
            b.En_Name = brand.En_Name;
            b.Country = brand.Country;
            b.En_Country = brand.En_Country;
            b.Introduction = brand.Introduction;
            b.Detail = brand.Detail;
            fileupload upf = new fileupload(Environment);
            if (brand.Pic != null)
            {
                b.Pic = upf.Upload(brand.Pic, brand.Name);
            }
            bllbrand.Edit(b);
            return RedirectToAction("Create", "Brand");
        }
        public IActionResult Delete(int id)
        {
            BLL_Brand bllBrand = new BLL_Brand();
            Brand brand = new Brand();
            bllBrand.Delete(id);
            return RedirectToAction("Create", "Brand");
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
            var modelcourse = new List<Models.Drag_Model>();
            foreach (var item in draglist)
            {
                if (Id == item.DragCategories.Select(s => s.CategoryId).SingleOrDefault())
                {
                    modelcourse.Add(new Drag_Model
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
                        CategoryId = item.DragCategories.Select(s => s.CategoryId).SingleOrDefault(),
                    });
                }
            }
            return View("User/MenuClickResultDrags", modelcourse);

        }
    }
}
