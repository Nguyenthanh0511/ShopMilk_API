using Model.Model;
using Reponsitory.Base;
using Reponsitory.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Repo
{
    public class CartDetailRepo : BaseRepo<CartDetail>,ICartDetailRepo
    {
        public CartDetailRepo(Shopmilk_5Context shop) : base(shop)
        {
        }
    }
}