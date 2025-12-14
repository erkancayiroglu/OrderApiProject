using OrderProject.DtoLayer.OrderBookDto1;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.OrderDto1
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }

        public List<OrderBookDto> OrderBooks { get; set; }
    }
}
