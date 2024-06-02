using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string CateId { get; set; } = null!;
        public string? CateName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
