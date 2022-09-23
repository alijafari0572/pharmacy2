using System;
using BE;
using BLL;
using DAL.Migrations;
using MD.PersianDateTime.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using pharmacy2;
using Blog = BE.Blog;

namespace pharmacy.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View("User/Blog");
        }

        public IActionResult Create()
        {
            return View("Admin/Create");
        }

        [HttpPost]
        public void Create(pharmacy2.Models.Blog_Model model)
        {
            Bll_Blog bld = new Bll_Blog();
            Blog blog = new Blog();
            blog.Titel = "salam";
            blog.Titel = "salam";
            blog.Date = PersianDateTime.Now.ToString("dddd, dd MMMM yyyy   HH:mm");
            blog.Text = model.Text;
            bld.create(blog);
        }
    }
}