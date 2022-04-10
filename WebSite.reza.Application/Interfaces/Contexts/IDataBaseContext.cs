using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSite.reza.Domain.Entities.Cart;
using WebSite.reza.Domain.Entities.Finances;
using WebSite.reza.Domain.Entities.HomePages;
using WebSite.reza.Domain.Entities.Orders;
using WebSite.reza.Domain.Entities.Products;
using WebSite.reza.Domain.Entities.Users;

namespace WebSite.reza.Application.Interfaces.Contexts
{
    public interface IDataBaseContext 
    {
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<UserInRole> userInRoles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductImages> ProductImages { get; set; }
        DbSet<ProductFeatures> ProductFeatures { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<HomePageImages> homePageImages { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<RequestPay> requestPays { get; set; }

        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetail { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
