using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class ProductDto
    {
       /* public ProductDto()
        {
            Galleries = new HashSet<Gallery>();
        }*/
        public string ProdId { get; set; }
        public string? ProdImageUrl { get; set; }
        public string? ProdTitle { get; set; }
        public decimal? ProdPrice { get; set; }
        public string? CateId { get; set; }
    }
}