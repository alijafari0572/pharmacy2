using System.Collections.Generic;
using System.Linq;
using BLL;
using Microsoft.AspNetCore.Mvc;
using pharmacy2.Models;


namespace pharmacy2.Viewcomponents.user
{
    public class NewDragsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL_Category bllCategory = new BLL_Category();
            ViewBag.CategoryViewBag = bllCategory.read();
            BLL_Drag bld = new BLL_Drag();
            List<BE.Drag> draglist = bld.NewDrags();
            var modelcourse = new List<Models.NewDrags_Model>();
            foreach (var item in draglist)
            {
                modelcourse.Add(new NewDrags_Model
                {
                        Id = item.Id,
                        Name = item.Name,
                        Detaile = item.Detaile,
                        Price = item.Price,
                        Exp_Date = item.Exp_Date,
                        Off_Price_Perset = item.Off_Price_Perset,
                        Off_Price = item.Off_Price,
                        Number = item.Number,
                        MaxOrder = item.MaxOrder,
                        MinOrder = item.MinOrder,
                        Pro_Date = item.Pro_Date,
                        Pic = item.Pic,
                        CategoryId = item.DragCategories.Select(s => s.CategoryId).SingleOrDefault(),
                        ParentCategoryId =bllCategory.MainCategoryId(item.DragCategories.Select(s => s.CategoryId).SingleOrDefault()).ParentId 
                    });
            }
            return View("_NewDrags", modelcourse);


        }
    }
}