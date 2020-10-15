using System;
using System.Collections.Generic;

namespace ShopBanHangDA5.Models
{
    public partial class ImportOrderDetail
    {
        public string ImportOrderDetailId { get; set; }
        public string ImportOrderDetailImportOrderId { get; set; }
        public string ImportOrderDetailProductId { get; set; }
        public string ImportOrderDetailProductName { get; set; }
        public int? ImportOrderDetailQuantity { get; set; }
        public int? ImportOrderDetailPrice { get; set; }

        public virtual ImportOrder ImportOrderDetailImportOrder { get; set; }
        public virtual Product ImportOrderDetailProduct { get; set; }
    }
}
