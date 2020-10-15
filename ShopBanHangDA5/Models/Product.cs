using System;
using System.Collections.Generic;

namespace ShopBanHangDA5.Models
{
    public partial class Product
    {
        public Product()
        {
            Comment = new HashSet<Comment>();
            ImportOrderDetail = new HashSet<ImportOrderDetail>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public string ProductDesc { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public int? ProductPrice { get; set; }
        public string ProductImage { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<ImportOrderDetail> ImportOrderDetail { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
