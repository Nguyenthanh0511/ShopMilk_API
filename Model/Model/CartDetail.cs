using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class CartDetail
    {
        public string CaId { get; set; } = null!;
        public string ProdId { get; set; } = null!;
        public int? Quantity { get; set; }
        public decimal? ProdPrice { get; set; }

        public virtual Cart Ca { get; set; } = null!;
        public virtual Product Prod { get; set; } = null!;
    }
}