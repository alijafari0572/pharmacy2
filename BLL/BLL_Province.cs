using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Province
    {
        public List<Province> Read()
        {
            DAL_Province P = new DAL_Province();
            return P.Read();
        }
        public Province GetCityById(int Id)
        {
            DAL_Province C = new DAL_Province();
            return C.GetProvinceById(Id);
        }
    }
}
