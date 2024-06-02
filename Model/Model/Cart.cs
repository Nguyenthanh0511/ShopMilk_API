using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        public string CaId { get; set; } = null!;
        public DateTime? CaDate { get; set; }
        public string? UId { get; set; }

        public virtual User? UIdNavigation { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
