using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Vouchers = new HashSet<Voucher>();
        }

        public string UId { get; set; } = null!;
        public string? UUserName { get; set; }
        public string? UEmail { get; set; }
        public string? UPassword { get; set; }
        public string? URole { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
