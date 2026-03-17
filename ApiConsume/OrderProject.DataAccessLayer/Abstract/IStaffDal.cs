using HotelProject.DataAccessLayer.Abstract;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.Abstract
{
    public interface IStaffDal:IGenericDal<Staff>
    {
        public List<Staff> GetFirst4Staff();
    }
}
