using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class Product
    {
        public Product()
        {
            CartDetails = new HashSet<CartDetail>();
            Galleries = new HashSet<Gallery>();
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public string ProdId { get; set; } = null!;
        public string? ProdImageUrl { get; set; }
        public string? ProdTitle { get; set; }
        public string? ProdDescription { get; set; }
        public string? ProdExpiry { get; set; }
        public string? ProdManual { get; set; }
        public string? ProdCanningSpecification { get; set; }
        public int? ProdCapacity { get; set; }
        public decimal? ProdPrice { get; set; }
        public string? CateId { get; set; }

        public virtual Category? Cate { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}

