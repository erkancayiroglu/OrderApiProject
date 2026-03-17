using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.OrderBookDto1
{
    public class CreateOrderBookDto
    {
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
