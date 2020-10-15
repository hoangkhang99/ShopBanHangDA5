using System;
using System.Collections.Generic;

namespace ShopBanHangDA5.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Comment = new HashSet<Comment>();
            HoaDon = new HashSet<HoaDon>();
            ImportOrder = new HashSet<ImportOrder>();
        }

        public string CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<ImportOrder> ImportOrder { get; set; }
    }
}
