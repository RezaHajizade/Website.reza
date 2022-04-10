using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Domain.Entities.Commons;
using WebSite.reza.Domain.Entities.Products;
using WebSite.reza.Domain.Entities.Users;

namespace WebSite.reza.Domain.Entities.Cart
{
    public class Cart:BaseEntity
    {
        public User Users { get; set; }
        public long? UserId { get; set; }
        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }

    public class CartItem:BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
