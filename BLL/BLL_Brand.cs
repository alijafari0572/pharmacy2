using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Brand
    {
        public void Create(Brand brand)
        {
            DAL_Brand dAL_Brand = new DAL_Brand();
            dAL_Brand.Create(brand);
        }

        public void Edit(Brand brand)
        {
            DAL_Brand dAL_Brand = new DAL_Brand();
            dAL_Brand.Edit(brand);
        }

        public void Delete(int id)
        {
            DAL_Brand dAL_brand = new DAL_Brand();
            dAL_brand.Delete(id);
        }

        public Brand SearchById(int Id)
        {
            DAL_Brand B = new DAL_Brand();
            return B.searchById(Id);
        }

        //public List<Drag> SearchByListId(List<Order_List> DragIds)
        //{
        //    DAL_Drag D = new DAL_Drag();
        //    return D.SearchByListId(DragIds);
        //}

        public List<Brand> Read()
        {
            DAL_Brand dal_brand = new DAL_Brand();
            return dal_brand.Read();
        }

        //public int gettotal()
        //{
        //    DAL_Drag d = new DAL_Drag();
        //    return d.gettotal();
        //}



        //public List<Drag> search(string tags)
        //{
        //    DAL_Drag D = new DAL_Drag();
        //    return D.search(tags);
        //}
    }
}
