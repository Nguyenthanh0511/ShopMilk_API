using Model.Model;
using Reponsitory.Base;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.IRepo
{
    public interface ICartDetailRepo:IBaseRepo<CartDetail>
    {
        //Thiết kế thêm để get theo
        public CartDetail Get(string cartId,string productid);
        public List<CartDetail> GetAllCart(string userId);
    }
}
