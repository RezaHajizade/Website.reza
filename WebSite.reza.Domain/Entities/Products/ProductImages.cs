using WebSite.reza.Domain.Entities.Commons;

namespace WebSite.reza.Domain.Entities.Products
{
    public class ProductImages:BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        //آدرس تصویر را در فیلد زیر ذخیره میکنیم
        public string Src { get; set; }
    }
}
