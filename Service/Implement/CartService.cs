using AutoMapper;
using Model.Model;
using Reponsitory.IRepo;
using Service.Base;
using Service.Dto;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class CartService : BaseService<Cart, CartDto, ICartRepo>,ICartService
    {
        private IProductRepo _productRepo;
        public CartService(ICartRepo trepo, IMapper _map, IProductRepo productRepo) : base(trepo, _map)
        {
            _productRepo = productRepo;
        }
        //public void AddCart(Cart cart)
        //{
        //    // Give info cart
        //    // Give infor product to cartdetail
        //    foreach(var item cart.CartDetails)
        //    {
        //        var product = _productRepo.Get(item.ProdId);

        //    }
        //    // Contain cartdetail of cart
        //}
    }
}
