using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.EntityLayer.Concrete
{
    public class OrderBook
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Piece { get; set; }

        public decimal TotalPrice { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
