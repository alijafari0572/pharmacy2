using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace DAL
{
    public class DAL_Blog
    {
        public void create(Blog B)
        {
            DB db = new DB();
            db.Blogs.Add(B);
            db.SaveChanges();
        }
    }
}
