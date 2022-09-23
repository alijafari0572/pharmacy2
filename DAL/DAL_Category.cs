using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public class DAL_Category
    {
        public void create(Category Category)
        {
            DB db = new DB();
            db.Categories.Add(Category);
            db.SaveChanges();
        }
        public List<Category> read()
        {
            DB db = new DB();
            return db.Categories.ToList();
        }


        public List<Category> raadMainCategory( )
        {
            DB db = new DB();
            var q = from i in db.Categories
                    where i.ParentId == 0
                    select i;
            return q.ToList();
        }
        public List<Category> SearchByListId(List<int> Ids)
        {

            DB db = new DB();
            var q = from i in db.Categories where Ids.Contains((i.Id)) select i;
            return q.ToList();
        }
        public Category MainCategoryId(int Id)
        {

            DB db = new DB();
            var q = from i in db.Categories 
                where i.Id==Id
                select i;
            return q.SingleOrDefault();
        }
    }
}
