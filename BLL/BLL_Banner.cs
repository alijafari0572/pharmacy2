using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class BLL_Banner
    {
        public void create(Banner banner)
        {
            DAL_Banner dAL_Banner = new DAL_Banner();
            dAL_Banner.create(banner);
        }

        //public void edite(Daro daro)
        //{
        //    DAL_Daro dAL_Daro = new DAL_Daro();
        //    dAL_Daro.edite(daro);
        //}

        //public Daro searchById(int Id)
        //{
        //    DAL_Daro D = new DAL_Daro();
        //    return D.searchById(Id);
        //}

        public List<Banner> read()
        {
            DAL_Banner B = new DAL_Banner();
            return B.read();
        }

        //public List<Daro> getskip(int c)
        //{
        //    DAL_Daro t = new DAL_Daro();
        //    return t.getskip(c);
        //}
    }
}