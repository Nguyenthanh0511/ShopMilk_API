using Microsoft.EntityFrameworkCore;
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
    public class CartRepo : BaseRepo<Cart>,ICartRepo
    {
        public Shopmilk_5Context _context;
        public CartRepo(Shopmilk_5Context shop) : base(shop)
        {
            _context = shop;
        }
        public Cart GetCartDetail(string caid,string prodid)
        {
            //return _context.Carts
            //    .Include(x => x.CartDetails)
            //    .ThenInclude(x => x.ProdId == prodid)
            //    .FirstOrDefault(x => x.CaId == caid);
            var cart = _context.Carts.Include(x => x.CartDetails).FirstOrDefault(x => x.CaId == caid);
            if(cart != null)
            {
                cart.CartDetails = cart.CartDetails.Where(x => x.ProdId == prodid).ToList();
            }
            return cart;
        }
    }
}