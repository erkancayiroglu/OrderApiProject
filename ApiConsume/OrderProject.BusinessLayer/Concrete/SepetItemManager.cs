using OrderProject.BusinessLayer.Abstract;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.BusinessLayer.Concrete
{
    public class SepetItemManager : ISepetItemService
    {
        private readonly ISepetItemDal _sepetItemDal;
        public SepetItemManager(ISepetItemDal sepetItemDal)
        {
            _sepetItemDal = sepetItemDal;
        }

        public void TAddToCard(int id, int userId)
        {
            _sepetItemDal.AddToCard(id,userId);
        }

        public void TDelete(SepetItem t)
        {
            _sepetItemDal.Delete(t);
        }

        public void TDeleteUserSepet(int userId)
        {
            _sepetItemDal.DeleteUserSepet(userId);
        }

        public SepetItem TGetById(int id)
        {
            return _sepetItemDal.GetById(id);
        }

        public List<SepetItem> TGetList()
        {
            return _sepetItemDal.GetList();
        }

        public decimal TGetPrice(int id)
        {
           return _sepetItemDal.GetPrice(id);
        }

        public List<SepetItem> TGetUserSepetItem(int id)
        {
            return _sepetItemDal.GetUserSepetItem(id);
        }

        public void TInsert(SepetItem t)
        {
            _sepetItemDal.Insert(t);
        }

        public void TUpdate(SepetItem t)
        {
            _sepetItemDal.Update(t);
        }
    }
}
