using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-378S14D\\SQLEXPRESS;Database=OrderApiProjectDb;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<SepetItem> SepetItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Booking> Bookings { get; set; }  
        
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<MessageCategory> MessageCategories { get; set; }

        public DbSet<OrderBook> OrderBooks { get; set; }

        public DbSet<SendEmail> SendEmails { get; set; }

      

    }
}
