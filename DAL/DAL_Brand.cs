using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public class DAL_Brand
    {
        public void Create(Brand brand)
        {
            DB db = new DB();

            db.Brands.Add(brand);
            db.SaveChanges();

        }

        public void Edit(Brand brand)
        {
            DB db = new DB();
            var q = (from i in db.Brands where i.Id == brand.Id select i).Single();
            q.Name = brand.Name;
            q.En_Name = brand.En_Name;
            q.Country = brand.Country;
            q.En_Country = brand.En_Country;
            q.Introduction = brand.Introduction;
            q.Detail = brand.Detail;
            if (brand.Pic != null)
            {
                q.Pic = brand.Pic;
            }
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            DB db = new DB();
            var q = from i in db.Brands where i.Id == id select i;
            Brand b = q.Single();
            db.Brands.Remove(b);
            db.SaveChanges();
        }


        public Brand searchById(int Id)
        {
            DB db = new DB();
            var q = from i in db.Brands
                    where i.Id == Id
                    select i;
            Brand b= q.Single();
            return b;
        }
        public List<Brand> Read()
        {
            DB db = new DB();
            return db.Brands.ToList();
        }

        //public List<Drag> SearchByListId(List<Order_List> DragIds)
        //{

        //    DB db = new DB();
        //    var dragList = DragIds.Select(l => l.DragId).ToList();
        //    var q = from i in db.Drags where dragList.Contains((i.Id)) select i;
        //    return q.ToList();
        //}

        //public int gettotal()
        //{
        //    DB db = new DB();
        //    return db.Drags.Count();
        //}


        //public List<Drag> search(string tags)
        //{
        //    List<Drag> D = new List<Drag>();
        //    DB db = new DB();
        //    var q = from i in db.Drags
        //            where i.Name.Contains(tags)
        //            select i;
        //    D = D.Concat(q.ToList()).ToList();
        //    return D;
        //}

    }
}
