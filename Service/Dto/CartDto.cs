using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class CartDto
    {
        public int CaId { get; set; }
        public DateTime Cadate { get; set; }
        public int UserId {  get; set; }
        public List<CartDetailDto> CartDetailDtos { get; set; }
    }
}
