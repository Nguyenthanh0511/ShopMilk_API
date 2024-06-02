using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class CartDetailDto
    {
        public int CaId { get; set; }
        public int ProdId { get; set; }
        public int? Quantity { get; set; }
        public decimal? ProdPrice { get; set; }
    }
}
