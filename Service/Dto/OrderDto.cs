using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class OrderDto
    {
        public string OrId { get; set; } = null!;
        public DateTime? OrDate { get; set; }
    }
}