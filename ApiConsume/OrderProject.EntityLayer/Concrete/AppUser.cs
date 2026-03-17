using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {

        public string Name { get; set; }
        public string LastName { get; set; }

 
        public string FullName
        {
            get 
            {
                return $"{Name} {LastName}";
            }
           
        }
        public List<Order> Orders { get; set; }
    }
}
