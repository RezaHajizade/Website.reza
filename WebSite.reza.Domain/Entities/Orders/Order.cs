using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Domain.Entities.Commons;
using WebSite.reza.Domain.Entities.Finances;
using WebSite.reza.Domain.Entities.Products;
using WebSite.reza.Domain.Entities.Users;

namespace WebSite.reza.Domain.Entities.Orders
{
    public class Order:BaseEntity
    {
        public virtual User User { get; set; } 
        public long UserId { get; set; }
        public virtual RequestPay RequestPay { get; set; }  
        public long RequestPayId { get; set; }
        public OrderState orderState { get; set; }

        //آدرس تحویل
        public string Address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail:BaseEntity
    {
        public virtual Order Order { get; set; }
        public long OrderId { get; set; }

        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }


    }

    public enum OrderState
    {
        [Display(Name ="در حال پردازش")]
        Processing=0,
        [Display(Name = "لغو شده")]
        Canceled =1,
        [Display(Name = "تحویل شده")]
        Deliverd =2,
    }

}
