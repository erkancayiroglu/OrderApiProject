using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.Restaurant
{
    public class CreateRestaurantDto
    {
        public string RestaurantName { get; set; }
        public string RestaurantImage { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPhone { get; set; }
    }
}
