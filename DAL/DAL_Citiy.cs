using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public class DAL_Citiy
    {
        public List<City> Read()
        {
            DB db = new DB();
            return db.Cities.ToList();
        }
        public List<City> GetCitiesById(int Id)
        {
            DB db = new DB();
            var q = from i in db.Cities 
                where i.ProvinceId == Id 
                select i ;
            return q.ToList();
            //var CityList = db.Cities.Where(c => c.ProvinceId == Id)
                //.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
          //  return CityList();
        }
        public City GetCityById(int Id)
        {
            DB db = new DB();
            var q = from i in db.Cities
                where i.Id == Id
                select i;
            return q.SingleOrDefault();
            
        }
    }
}
