using System;
using System.Collections.Generic;

namespace ShopBanHangDA5.Models
{
    public partial class ImportOrder
    {
        public ImportOrder()
        {
            ImportOrderDetail = new HashSet<ImportOrderDetail>();
        }

        public string ImportOrderId { get; set; }
        public string ImportOrderCustomersId { get; set; }
        public int? ImportOrderPrice { get; set; }
        public string ImportOrderName { get; set; }

        public virtual Customers ImportOrderCustomers { get; set; }
        public virtual ICollection<ImportOrderDetail> ImportOrderDetail { get; set; }
    }
}
