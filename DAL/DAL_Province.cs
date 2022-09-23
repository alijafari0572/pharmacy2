using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public class DAL_Province
    {
        public List<Province> Read()
        {
            DB db = new DB();
            return db.Provinces.ToList();
        }
        public Province GetProvinceById(int Id)
        {
            DB db = new DB();
            var q = from i in db.Provinces
                where i.Id == Id
                select i;
            return q.SingleOrDefault();

        }
    }
}
