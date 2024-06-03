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
    //Thiết kế lại theo dạng ShopCart
    public class CartDetailService : ICartDetailService<CartDetail>
    {
        private readonly IProductRepo _productRepo;
        private readonly ICartRepo _cartRepo;
        private readonly ICartDetailRepo _cartDetailRepo;
        public bool Flag { get; set; }
        public CartDetail ObjectDetail { get; set; }
        public List<CartDetail> ObjList { get; set; }
        public string Error { get; set; }
        public CartDetailService(IProductRepo productRepo, ICartRepo cartRepo, ICartDetailRepo cartDetailRepo)
        {
             Flag = true;
            Error = "";
            _productRepo = productRepo;
            _cartRepo = cartRepo;
            _cartDetailRepo = cartDetailRepo;
            ObjectDetail = new CartDetail();
            ObjList = new List<CartDetail>();
        }

        public void addcartdetail(string UserId,string productid, int quantity)
        {
            try
            {
                //Check user
                var cart = _cartRepo.GetAll().FirstOrDefault(x => x.UId == UserId);
                if(cart== null)
                {
                    cart = new Cart
                    {
                        CaId = Guid.NewGuid().ToString().Substring(0, 5),
                        CaDate = DateTime.Now,
                        UId = UserId,
                        CartDetails = new List<CartDetail>()
                    };
                    _cartRepo.Create(cart);
                }
                //check product
                var product = _productRepo.Get(productid);
                if(product==null)
                {
                    Flag = false;
                    return;
                }
                var cartId = _cartRepo.Get(cart.CaId).CaId;
                var cartdetails = _cartDetailRepo.Get(cartId,productid);
                var price = _productRepo.Get(productid).ProdPrice;
                //check cartdetail
                if (cartdetails != null)
                {
                    cartdetails.Quantity += quantity;
                    cartdetails.ProdPrice += quantity * (cartdetails.Prod.ProdPrice);
                    _cartDetailRepo.Update(cartdetails);
                }
                else
                {
                    cartdetails = new CartDetail
                    {
                        ProdId = productid,
                        CaId = _cartRepo.Get(cart.CaId).CaId,
                        Quantity = quantity,
                        ProdPrice = price * quantity,
                        Prod = _productRepo.Get(productid),
                        Ca = _cartRepo.Get(_cartRepo.Get(cart.CaId).CaId)
                    };
                    _cartDetailRepo.Create(cartdetails);
                }
                ObjectDetail = cartdetails;
              
            }catch(Exception ex)
            {
                ex.ToString();
                Flag = false;
            }
        }

        public void removecartdetail(string UserId, string productid,int quantity)
        {
            
            var cart = _cartRepo.GetAll().FirstOrDefault(x=>x.UId==UserId);
            if(cart == null)
            {
                Error = "User not add into a cart";
                return;
            }
            var product = _productRepo.Get(productid);
            if(product == null)
            {
                Error = "Not contains product";
                return;
            }
            //Remove to quantity of cartdetail
            var cartdetails = _cartDetailRepo.Get(cart.CaId,productid);
            if(cartdetails == null)
            {
                Error = "False";
                return;
            }
            else
            {
                if(cartdetails.Quantity>0)
                {
                    cartdetails.Quantity -= quantity;
                    _cartDetailRepo.Update(cartdetails);
                }
                else
                {
                    _cartDetailRepo.Delete(cartdetails);
                }
            }
            //Cart detail = 0 and then delete all
        }

        public void getAllCartDetail(string UserId)
        {
            try
            {
                var cart = _cartRepo.GetAll().FirstOrDefault(x => x.UId == UserId);
                //Check user have cart contants detail have product

                ObjList = _cartDetailRepo.GetAllCart(UserId);
            }catch(Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }


        //    public void AddCartDetail(CartDetail cartdetail)
        //    {
        //        // Idea: Give carid and prodid ( objdetail )
        //        try
        //        {
        //            this.ObjDetail = this.ThisRepo._contex.FirstOrDefault(x => x.ProdId == cartdetail.ProdId && x.CaId == cartdetail.CaId);
        //            if(this.ObjDetail != null ) {
        //                this.ObjDetail.Quantity += cartdetail.Quantity;
        //                ThisRepo.Update(this.ObjDetail);
        //            }
        //            else
        //            {
        //                ThisRepo.Create(cartdetail);
        //            }
        //        }catch(Exception ex)
        //        {
        //            Error = ex.Message;
        //            Flag = false;
        //        }
        //    }


    }
}
