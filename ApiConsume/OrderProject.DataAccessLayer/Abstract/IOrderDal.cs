using HotelProject.DataAccessLayer.Abstract;
using OrderProject.DtoLayer.OrderDto1;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.Abstract
{
    public interface IOrderDal: IGenericDal<Order>
    {
        public OrderDetailDto GetOrderDetails(int id);
    }
}
