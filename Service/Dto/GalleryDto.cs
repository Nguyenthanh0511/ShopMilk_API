using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class GalleryDto
    {
        public int GId { get; set; }
        public string? GThumbnail { get; set; }
        public int? ProdId { get; set; }
        /*public virtual ProductDto? Prod { get; set; }*/
    }
}