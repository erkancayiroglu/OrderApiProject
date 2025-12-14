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
    public class RestaurantManager : IRestaurantService
    {
        private readonly IRestaurantDal _restaurantDal;
        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }
        public void TDelete(Restaurant t)
        {
           _restaurantDal.Delete(t);
        }

        public Restaurant TGetById(int id)
        {
            return _restaurantDal.GetById(id);  
        }

        public List<Restaurant> TGetList()
        {
            return _restaurantDal.GetList();    
        }

        public void TInsert(Restaurant t)
        {
            _restaurantDal.Insert(t);
        }

        public void TUpdate(Restaurant t)
        {
            _restaurantDal.Update(t);
        }
    }
}
