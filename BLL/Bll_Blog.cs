using BE;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class Bll_Blog
    {
        public void create(Blog blog)
        {
            DAL_Blog dAL_blog = new DAL_Blog();
            dAL_blog.create(blog);
        }
    }
}
