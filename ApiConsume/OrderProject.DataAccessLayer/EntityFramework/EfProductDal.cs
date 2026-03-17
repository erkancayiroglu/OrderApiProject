using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }
        public List<Product> GetProductList(int id)
        {
            var context = new Context();
            return context.Products
          .Where(x => x.CategoryId == id)
          .ToList();
        }


    }
}
