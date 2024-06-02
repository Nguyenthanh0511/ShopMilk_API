using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public string OrId { get; set; } = null!;
        public DateTime? OrDate { get; set; }
        public string? UId { get; set; }

        public virtual User? UIdNavigation { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
