using System;
using System.Collections.Generic;

namespace ShopBanHangDA5.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string OrderDiachi { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
