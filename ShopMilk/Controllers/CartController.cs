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
        //private ICartService _Service;
        public CartController(ICartService _service) : base(_service)
        {
        }
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