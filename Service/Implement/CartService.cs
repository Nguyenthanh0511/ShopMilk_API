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
        private ICartDetailRepo _cartDetailRepo;
        public CartService(ICartRepo trepo, IMapper _map, IProductRepo productRepo,ICartDetailRepo _cartDetailRepo) : base(trepo, _map)
        {
            _cartDetailRepo = _cartDetailRepo;
            _productRepo = productRepo;
        }



        /// Đoạn code dưới không dùng đến, để lại đọc để cho biết cái ngu ở đâu :)))
        public void AddToCart(string userId, string productId, int quantity)
        {
            Console.WriteLine("Product id:", productId);
            try
            {
                // Check if user has a cart
                var cart = ThisRepo.GetAll().FirstOrDefault(c => c.UId == userId); // trả về nhiều cart
                if (cart == null)
                {
                    // Create a new cart for the user
                    cart = new Cart
                    {
                        CaId = Guid.NewGuid().ToString().Substring(0, 15),
                        CaDate = DateTime.Now,
                        UId = userId,
                        CartDetails = new HashSet<CartDetail>()
                    };
                    ThisRepo.Create(cart);
                }
                else if (cart.CartDetails == null)
                {
                    cart.CartDetails = new HashSet<CartDetail>();
                }

                // Check if the product exists
                var product = _productRepo.Get(productId);
                if (product == null)
                {
                    Flag = false;
                    Error = "Product not found.";
                    return;
                }

                //foreach (var cartdetails in cart.CartDetails)
                //{
                //    if (cartdetails != null)
                //    {
                //        cartdetails.Quantity += quantity;
                //        cartdetails.ProdPrice = cartdetails.Quantity * (product.ProdPrice ?? 0);
                //        _cartDetailRepo.Update(cartdetails);
                //    }
                //    else
                //    {
                //        cartdetails.Quantity = quantity;
                //        cartdetails.ProdId = product.ProdId;
                //        cartdetails.CaId = cart.CaId;
                //        cartdetails.Ca = cart;
                //        cartdetails.Prod = product;
                //    _cartDetailRepo.Create(cartdetails);
                //    };
                //}


                // Check if the product is already in the cart
                var cartdetail = cart.CartDetails.FirstOrDefault(cd => cd.ProdId == productId && cd.CaId == cart.CaId);

                if (cartdetail != null)
                {
                    // update quantity and price if product already exists in the cart
                    cartdetail.Quantity += quantity;
                    cartdetail.ProdPrice = cartdetail.Quantity * (product.ProdPrice ?? 0);
                    _cartDetailRepo.Update(cartdetail); // ensure the cart detail is updated
                }
                else
                {
                    product.CartDetails = new HashSet<CartDetail>();
                    // add new product to the cart
                    cartdetail = new CartDetail
                    {
                        ProdId = productId,
                        CaId = cart.CaId,
                        Quantity = quantity,
                        ProdPrice = quantity * (product.ProdPrice ?? 0),
                        Ca = cart,
                        Prod = product
                    };
                    _cartDetailRepo.Create(cartdetail);
                    cart.CartDetails.Add(cartdetail); // ensure the cart detail is added to the cart
                    product.CartDetails.Add(cartdetail);
                }
                _productRepo.Update(product);
                ThisRepo.Update(cart);
                ObjDetail = cart;
                Flag = true; // Set flag to true to indicate success
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public void GetAllCart()
        {
            throw new NotImplementedException();
        }

        public void RemoveToCart(string CartId, string ProductId)
        {
            //
            //ThisRepo.GetCartDetail(CartId);
            ObjDetail = ThisRepo.GetCartDetail(CartId,ProductId);
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
