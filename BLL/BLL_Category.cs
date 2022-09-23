using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Category
    {
        public void create(Category Category)
        {
            DAL_Category dal = new DAL_Category();
            dal.create(Category);
        }
        public List<Category> read()
        {
            DAL_Category Category = new DAL_Category();
            return Category.read();
        }

        public List<Category> readMainCategories()
        {
            DAL_Category Category = new DAL_Category();
            return Category.raadMainCategory();
        }
        public List<Category> SearchByListId(List<int> Ids)
        {
            DAL_Category B = new DAL_Category();
            return B.SearchByListId(Ids);
        }
        //public Main_Category searchById(int id)
        //{
        //    DAL_Category c = new DAL_Category();
        //    return c.searchById(id);
        //}
        public Category MainCategoryId(int Id)
        {
            DAL_Category dal_Category = new DAL_Category();
            return dal_Category.MainCategoryId(Id);
        }
    }
}
