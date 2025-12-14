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

        public int UserId { get; set; }

        public AppUser User { get; set; }

        public int Piece { get; set; }

       

        public decimal TotalPrice { get; set; }



    }
}
