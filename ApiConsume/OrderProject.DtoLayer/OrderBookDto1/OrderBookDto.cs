using OrderProject.DtoLayer.Products;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.OrderBookDto1
{
    public class OrderBookDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public IndexProductDto Product { get; set; }

        public int Piece { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
