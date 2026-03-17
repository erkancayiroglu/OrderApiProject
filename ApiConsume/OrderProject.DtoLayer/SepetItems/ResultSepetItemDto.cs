using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.SepetItems
{
    public class ResultSepetItemDto
    {
     public List<SepetItem> SepetItems { get; set; }    

        public decimal TotalAmount { get; set; }

    }
}
