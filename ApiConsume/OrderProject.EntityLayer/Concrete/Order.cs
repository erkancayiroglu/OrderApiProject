using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProject.EntityLayer.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }


        public AppUser User { get; set; }


        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }

        public string OrderStatus { get; set; }

    

        public List<OrderBook> OrderBooks { get; set; }
    }
}
