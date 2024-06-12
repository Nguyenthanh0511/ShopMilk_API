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
    public class CartDetailRepo : BaseRepo<CartDetail>,ICartDetailRepo
    {
        private Shopmilk_5Context _context;
        public CartDetailRepo(Shopmilk_5Context shop) : base(shop)
        {
            _context = shop;
        }

        public CartDetail Get(string cartId, string productid)
        {
            return _context.CartDetails.Find(cartId, productid);
        }

        List<CartDetail> ICartDetailRepo.GetAllCart(string userId)
        {
            //var cartDetail = _context.CartDetails.Where(x=>x.CaId == cartId).ToList();
            //return cartDetail;
            var listCart = _context.Carts.Where(u => u.UId == userId)
                    .Include(c => c.CartDetails)
                    .ThenInclude(p => p.Prod)
                    .SelectMany(mn => mn.CartDetails)
                    .ToList();
            return listCart;
        }
    }
}