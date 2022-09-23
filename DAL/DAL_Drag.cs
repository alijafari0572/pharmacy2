using System.Collections.Generic;
using BE;
using System.Linq;
using System.Threading;
using DAL.Migrations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore;
using Brand = BE.Brand;

namespace DAL
{
    public class DAL_Drag
    {
        public void create(Drag D, List<int> category)
        {
            DB db = new DB();
            //var Categorys = new List<int>();
            foreach (var item in category)
            {
                Category C1 = db.Categories.Where(i => i.Id == item).Single();
                D.DragCategories.Add(new Drag_Category()
                {
                    Catagory = C1,
                    CategoryId = C1.Id
                });
            }
            db.Drags.Add(D);
            db.SaveChanges();
        }

        public void edit(Drag drag, List<int> category)
        {
            DB db = new DB();
            Drag_Category DC = new Drag_Category();

            {
                //var q = (from i in db.Drags where i.Id == drag.Id select i).Single();
                var q = (from i in db.Drags.Include(a => a.DragCategories).ThenInclude(a => a.Drag)
                    where i.Id == drag.Id
                    select i).Single();
                q.DragCategories.Clear();
                q.Name = drag.Name;
                q.En_Name = drag.En_Name;
                q.Detaile = drag.Detaile;
                q.Price = drag.Price;
                q.Exp_Date = drag.Exp_Date;
                q.Off_Price_Perset = drag.Off_Price_Perset;
                q.Off_Price = drag.Off_Price;
                q.Number = drag.Number;
                q.MaxOrder = drag.MaxOrder;
                q.MinOrder = drag.MinOrder;
                q.Pro_Date = drag.Pro_Date;
                foreach (var item in category)
                {
                    Category C1 = db.Categories.Where(i => i.Id == item).Single();
                    q.DragCategories.Add(new Drag_Category()
                    {
                        Catagory = C1,
                        CategoryId = C1.Id
                    });
                }
            }
            db.SaveChanges();
        }

        public void delete(int id)
        {
            DB db = new DB();
            var q = from i in db.Drags where i.Id == id select i;
            Drag d = q.Single();
            db.Drags.Remove(d);
            db.SaveChanges();
        }


        public Drag searchById(int Id)
        {
            DB db = new DB();
            //var q = from i in db.Drags
            //        where i.Id == Id
            //        select i;
            //return q.Single();
            var r = from i in db.Drags.Include(a => a.DragCategories).ThenInclude(a => a.Drag)
                where i.Id == Id
                    select i;
            return r.Single();
        }
        public List<Drag> read()
        {
            DB db = new DB();
            return db.Drags.ToList();
        }

        public List<Drag> SearchByListId(List<Order_List> DragIds)
        {
            
            DB db = new DB();
            var dragList = DragIds.Select(l => l.DragId).ToList();
            var q = from i in db.Drags where dragList.Contains((i.Id)) select i;
            return q.ToList();
        }

        public int gettotal()
        {
            DB db = new DB();
            return db.Drags.Count();
        }

        public List<Drag> getskip(int c)
        {
            int t = c * 10;
            DB db = new DB();
            var q = db.Drags.Skip(t).Take(10);
            return q.ToList();
        }
        public List<Drag> search(string tags)
        {
            List<Drag> D = new List<Drag>();
            DB db = new DB();
                var q = from i in db.Drags
                    where i.Name.Contains(tags)
                    select i;
                D = D.Concat(q.ToList()).ToList();
                return D;
        }

        public List<Drag> MenuClickResult(int Id)
        {
             DB db = new DB();
            List<Drag> D = new List<Drag>();
            var q = from i in db.Drags
                    .Include(s => s.DragCategories)
                    .ThenInclude(s => s.Catagory)
                select i;
            D = q.ToList();
            return D;
        }
        public List<Drag> NewDrags()
        {
            DB db = new DB();
            List<Drag> D = new List<Drag>();
            var q = from i in db.Drags
                    .Include(s => s.DragCategories)
                    .ThenInclude(s => s.Catagory)
                    select i;
            q = q.OrderByDescending(D=>D.Id);
            D = q.ToList();
            return D;
        }


    }
}