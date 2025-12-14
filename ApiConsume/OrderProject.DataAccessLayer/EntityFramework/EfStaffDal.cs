using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repositories;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DataAccessLayer.Concrete;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal:GenericRepository<Staff>,IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> GetFirst4Staff()
        {
            var context = new Context();
            return context.Staffs.Take(4).ToList();
        }
    }
}
