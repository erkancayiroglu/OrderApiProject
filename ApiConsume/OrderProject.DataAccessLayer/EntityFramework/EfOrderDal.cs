using HotelProject.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DataAccessLayer.Concrete;
using OrderProject.DtoLayer.OrderBookDto1;
using OrderProject.DtoLayer.OrderDto1;
using OrderProject.DtoLayer.Products;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(Context context) : base(context)
        {
        }

        public OrderDetailDto GetOrderDetails(int id)
        {
            using var context = new Context();

            return context.Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDetailDto
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    OrderStatus = o.OrderStatus,

                    OrderBooks = o.OrderBooks.Select(ob => new OrderBookDto
                    {
                        Id = ob.Id,
                        ProductId = ob.ProductId,
                        Piece = ob.Piece,
                        TotalPrice = ob.TotalPrice,

                        Product = new IndexProductDto
                        {
                            Id = ob.Product.Id,
                            Name = ob.Product.Name,
                            Price = ob.Product.Price,
                            Stock = ob.Product.Stock,
                            ImageUrl = ob.Product.ImageUrl,
                            CategoryId = ob.Product.CategoryId
                        }
                    }).ToList()
                })
                .FirstOrDefault();
        }
        public List<OrderUserDto> GetOrderUser(int userId)
        {
            using var context = new Context();

            return context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderUserDto
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    OrderStatus = o.OrderStatus
                })
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }







    }
    
}
