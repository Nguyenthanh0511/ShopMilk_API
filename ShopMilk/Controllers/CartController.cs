using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Reponsitory.IRepo;
using Service.Dto;
using Service.Interface;
using ShopMilk.Controllers.NewFolder;

namespace ShopMilk.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : BaseController<Cart, CartDto, ICartRepo, ICartService>
    {
        //private IProductRepo productRepo;
        private ICartService _Service;
        private IMapper _map;
        public CartController(ICartService _service,IMapper map) : base(_service)
        {
            _Service = _service;
            _map = map;
        }
        //[HttpPost("{userId}/add")]
        //public IActionResult AddToCart([FromForm]string userId, [FromForm]string productId, [FromForm]int quantity) {
        //    _Service.AddToCart(userId, productId, quantity);
        //    if (_Service.Flag)
        //    {
        //        return Ok(_Service.ObjDetail);
        //    }
        //    else
        //    {
        //        return BadRequest(_Service.Error);
        //    }
        //}

        //[HttpGet]
        //public IActionResult GetRemove(string cartId,string productId)
        //{
        //    _Service.RemoveToCart(cartId, productId);
        //    if (_Service.Flag)
        //    {
        //        return Ok(_Service.ObjDetail);
        //    }
        //    else
        //    {
        //        return BadRequest(_Service.Error);
        //    }
        //}
        //[HttpPost]
        //public IActionResult AddToCart(Product product)
        //{
        //    // Lấy product theo id
        //    var prod = productRepo.Get(product.ProdId);
        //    // Thêm product theo id vào
        //    _Service.Create();
        //}
    }
}