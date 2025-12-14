using HotelProject.DataAccessLayer.Repositories;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DataAccessLayer.Concrete;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.EntityFramework
{
    public class EfRestaurantDal : GenericRepository<Restaurant>, IRestaurantDal
    {
        public EfRestaurantDal(Context context) : base(context)
        {
        }
    }
}
