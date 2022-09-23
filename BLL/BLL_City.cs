using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class BLL_City
    {
        public List<City> Read()
        {
            DAL_Citiy C = new DAL_Citiy();
            return C.Read();
        }
        public List<City> GetCitiesById(int Id)
        {
            DAL_Citiy C = new DAL_Citiy();
            return C.GetCitiesById(Id);
        }
        public City GetCityById(int Id)
        {
            DAL_Citiy C = new DAL_Citiy();
            return C.GetCityById(Id);
        }
    }
}
