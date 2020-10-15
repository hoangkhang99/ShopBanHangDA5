using System;
using System.Collections.Generic;

namespace ShopBanHangDA5.Models
{
    public partial class OrderDetails
    {
        public string OrderDetailsId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductSalesQuantity { get; set; }

        public virtual HoaDon Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
