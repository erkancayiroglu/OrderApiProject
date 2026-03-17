using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.BusinessLayer.Abstract
{
    public interface ISepetItemService: IGenericService<SepetItem>
    {
        public decimal TGetPrice(int id);
        public List<SepetItem> TGetUserSepetItem(int id);
        public void TDeleteUserSepet(int userId);

        public void TAddToCard(int id,int userId);
    }
}
