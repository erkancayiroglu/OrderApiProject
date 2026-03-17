using HotelProject.DataAccessLayer.Abstract;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.Abstract
{
    public interface ISepetItemDal: IGenericDal<SepetItem>
    {
        public decimal GetPrice(int id);

        public List<SepetItem> GetUserSepetItem(int id);
        public void DeleteUserSepet(int userId);

        public void AddToCard(int id, int userId);
    }
}
