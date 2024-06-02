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
    public class OrderDetailRepo : BaseRepo<OrdersDetail>,IOrderDetail
    {
        public OrderDetailRepo(Shopmilk_5Context shop) : base(shop)
        {
        }
    }
}
