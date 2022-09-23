using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Drag
    {
        public void create(Drag daro, List<int> category)
        {
            DAL_Drag dAL_Drag = new DAL_Drag();
            dAL_Drag.create(daro, category);
        }

        public void edit(Drag drag, List<int> category)
        {
            DAL_Drag dAL_Drag = new DAL_Drag();
            dAL_Drag.edit(drag, category);
        }

        public void delete(int id)
        {
            DAL_Drag dAL_Drag = new DAL_Drag();
            dAL_Drag.delete(id);
        }

        public Drag searchById(int Id)
        {
            DAL_Drag D = new DAL_Drag();
            return D.searchById(Id);
        }

        public List<Drag> SearchByListId(List<Order_List> DragIds)
        {
            DAL_Drag D = new DAL_Drag();
            return D.SearchByListId(DragIds);
        }

        public List<Drag> read()
        {
            DAL_Drag D = new DAL_Drag();
            return D.read();
        }

        public int gettotal()
        {
            DAL_Drag d = new DAL_Drag();
            return d.gettotal();
        }

        public List<Drag> getskip(int c)
        {
            DAL_Drag d = new DAL_Drag();
            return d.getskip(c);
        }

        public List<Drag> search(string tags)
        {
            DAL_Drag D = new DAL_Drag();
            return D.search(tags);
        }

        public List<Drag> MenuClickResult(int Id)
        {
            DAL_Drag D = new DAL_Drag();
            return D.MenuClickResult(Id);
        }
        public List<Drag> NewDrags()
        {
            DAL_Drag D = new DAL_Drag();
            return D.NewDrags();
        }
    }
}