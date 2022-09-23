using System;
using BE;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace DAL
{
    public class DAL_Banner
    {
        public void create(Banner B)
        {
            if (SearchStateBanner(B) == false)
            {
                DB db = new DB();
                db.Banners.Add(B);
                db.SaveChanges();
            }
           
        }

        public List<Banner> read()
        {
            DB db = new DB();
            return db.Banners.ToList();
        }

        public bool SearchStateBanner(Banner B)
        {
            DB db = new DB();
            var q = from i in db.Banners
                    where i.Name == B.Name &&i.State==true select i;
            if (q.Any())
            {
                Banner BB = new Banner();
                BB = q.Single();
                BB.State = false;
                db.SaveChanges();
                return false;
            }
            else
            {
                return false;
            }
            
        }
        //public void edite(Daro D)
        //{
        //    DB db = new DB();
        //    var q = from i in db.Daros where i.Id == D.Id select i;
        //    Daro DD = new Daro();
        //    DD = q.Single();
        //    DD.Name = D.Name;
        //    DD.Price = D.Price;
        //    DD.Off_Pric = D.Off_Pric;
        //    DD.Man_Date = D.Man_Date;
        //    DD.Exp_Date = D.Exp_Date;
        //    if (D.Pic != "")
        //    {
        //        DD.Pic = D.Pic;
        //    }
        //    db.SaveChanges();
        //}
    }
}