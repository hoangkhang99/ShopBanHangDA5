using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopBanHangDA5.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }
        [Key]
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDesc { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]

        public virtual ICollection<Product> Product { get; set; }
    }
}
