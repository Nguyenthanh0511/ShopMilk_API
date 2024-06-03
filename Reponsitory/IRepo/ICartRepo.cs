using Model.Model;
using Reponsitory.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.IRepo
{
    public interface ICartRepo : IBaseRepo<Cart>
    {
        //Thêm cart thì sẽ tăng thêm số lượng
        Cart GetCartDetail(string id,string prodid); //( có thể xá
    }
}