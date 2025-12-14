using HotelProject.DataAccessLayer.Repositories;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DataAccessLayer.Concrete;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        { }

     
    }
}
