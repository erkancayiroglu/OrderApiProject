using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.SepetItems
{
    public class CreateSepetItemDto
    {
        

        public int ProductId { get; set; } // Ürün ID'si

     
        public int UserId { get; set; }

       

        public int Piece { get; set; }


    }
}
