using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.EntityLayer.Concrete
{
    public class SepetItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
      
        public int Piece { get; set; }

        public int TotalPrice 
        { 
            get
            {
                return (int)(Product != null ? Product.Price * Piece : 0);
            }
        }
    }
}
