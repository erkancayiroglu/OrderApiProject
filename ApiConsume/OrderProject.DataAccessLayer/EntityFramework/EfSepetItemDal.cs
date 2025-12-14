using HotelProject.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DataAccessLayer.Concrete;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.EntityFramework
{
    public class EfSepetItemDal : GenericRepository<SepetItem>, ISepetItemDal
    {
        private readonly UserManager<AppUser> _userManager;

        public EfSepetItemDal(Context context) : base(context)
        {
        }

        public void AddToCard(int productId, int userId)
        {
            using var context = new Context();

            // Ürünü al
            var product = context.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
                return;

            var sepetItem = context.SepetItems
                .FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);

            if (sepetItem == null)
            {
                sepetItem = new SepetItem
                {
                    ProductId = productId,
                    UserId = userId,
                    Piece = 1,
                    TotalPrice = product.Price   // ⭐ İLK FİYAT
                };

                context.SepetItems.Add(sepetItem);
            }
            else
            {
                sepetItem.Piece++;
                sepetItem.TotalPrice += product.Price; // ⭐ ARTTIR
            }

            context.SaveChanges();
        }


        public void DeleteUserSepet(int userId)
        {
            using var context = new Context();

        
            var items = context.SepetItems
                .Where(x => x.UserId == userId)
                .ToList();

           
            if (items.Count == 0)
                return;

            context.SepetItems.RemoveRange(items);

            context.SaveChanges();
        }

        public decimal GetPrice(int productId)
        {
            using var context = new Context();
            var product = context.Products.Find(productId);
            return product != null ? product.Price : 0;
        }
        public  List<SepetItem> GetUserSepetItem(int id)
        {
            using var context = new Context();

            return  context.SepetItems
                                .Where(x => x.UserId == id)
                                .Include(x => x.Product).ToList();
                               

        }
    }
}
