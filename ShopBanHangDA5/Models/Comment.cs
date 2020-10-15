using System;
using System.Collections.Generic;

namespace ShopBanHangDA5.Models
{
    public partial class Comment
    {
        public string CommentId { get; set; }
        public string CommentCustomersId { get; set; }
        public string CommentDesc { get; set; }
        public string CommentProductId { get; set; }

        public virtual Customers CommentCustomers { get; set; }
        public virtual Product CommentProduct { get; set; }
    }
}
