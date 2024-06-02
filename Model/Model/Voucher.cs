using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class Voucher
    {
        public string VId { get; set; } = null!;
        public int? VPriceSale { get; set; }
        public string? UId { get; set; }

        public virtual User? UIdNavigation { get; set; }
    }
}
