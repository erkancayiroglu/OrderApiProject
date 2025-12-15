using OrderProject.DtoLayer.OrderDto1;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.BusinessLayer.Abstract
{
    public interface IOrderService: IGenericService<Order>
    {
        public  OrderDetailDto TGetOrderDetails(int id);

        public List<OrderUserDto> TGetOrder(int userId);

        public List<ResultOrdersDto> TGetOrders();


    }
}
