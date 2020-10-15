using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopBanHangDA5.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Product> Product { get; set; }
    }
}
