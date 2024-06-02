using System;
using System.Collections.Generic;

namespace Model.Model
{
    public partial class Gallery
    {
        public string GId { get; set; } = null!;
        public string? GThumbnail { get; set; }
        public string? ProdId { get; set; }

        public virtual Product? Prod { get; set; }
    }
}
