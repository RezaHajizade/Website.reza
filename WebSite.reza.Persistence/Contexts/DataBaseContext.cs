using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Domain.Entities.Cart;
using WebSite.reza.Domain.Entities.Finances;
using WebSite.reza.Domain.Entities.HomePages;
using WebSite.reza.Domain.Entities.Orders;
using WebSite.reza.Domain.Entities.Products;
using WebSite.reza.Domain.Entities.Users;

namespace WebSite.reza.Persistence.Contexts
{
    public class DataBaseContext : IdentityDbContext<User, Role, string>, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserInRole> userInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImages> homePageImages { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<RequestPay> requestPays { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(p => p.User)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.RequestPay)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            //    modelBuilder.Entity<IdentityUserLogin<string>>.HasNoKey();



            //send Data
            // SendData(modelBuilder);


            //اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.ProviderKey, p.LoginProvider });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider });


            //عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);

        }

        public void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<HomePageImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(p => !p.IsRemoved);

        }

        //public void SendData(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Role>().HasData(new Role { RoleId = 1, Name = nameof(UserRoles.Admin) });
        //    modelBuilder.Entity<Role>().HasData(new Role { RoleId = 2, Name = nameof(UserRoles.Operator) });
        //    modelBuilder.Entity<Role>().HasData(new Role { RoleId = 3, Name = nameof(UserRoles.Customer) });
        //}
    }
}
