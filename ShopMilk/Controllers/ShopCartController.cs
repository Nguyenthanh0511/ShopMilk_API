using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Reponsitory.IRepo;
using Service.Dto;
using Service.Implement;
using Service.Interface;
using ShopMilk.Controllers.NewFolder;

namespace ShopMilk.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopCartController : ControllerBase
    {
        private readonly ICartDetailService<CartDetail> _Service;
        public ShopCartController(ICartDetailService<CartDetail> _service)
        {
            _Service = _service;
        }
        [HttpPost("{userId}/add")]
        public IActionResult AddCart([FromForm] string UserId, [FromForm] string Productid, [FromForm] int quantity)
        {

            _Service.addcartdetail(UserId, Productid, quantity);
            if (_Service.Flag)
            {
                return Ok(_Service.ObjectDetail);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("{userId}/add")]
        public IActionResult RemoveCart([FromForm] string UserId, [FromForm] string Productid, [FromForm] int quantity)
        {
            _Service.removecartdetail(UserId, Productid, quantity);
            if (_Service.Flag)
            {
                return Ok("Remove succesfully");
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpGet("{userId}")]
        public IActionResult GetCart(string userId)
        {
            _Service.getAllCartDetail(userId);
            var getAllCart = _Service.ObjList;
            if (_Service.Flag)
            {
                return Ok(getAllCart.Select(cd => new
                {
                    cd.CaId,
                    cd.ProdId,
                    cd.Quantity,
                    cd.ProdPrice,
                    Product = new
                    {
                        cd.Prod.ProdId, cd.Prod.ProdTitle
                    }
                }));
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }

        //[HttpGet("{userId}")]
        //public IActionResult GetCart([FromForm] string userId)
        //{
        //    _Service.getAllCartDetail(userId);
        //    if (_Service.Flag)
        //    {
        //        return Ok(_Service.ObjList);
        //    }
        //    else
        //    {
        //        return BadRequest(_Service.Error);
        //    }
        //}
    }
}
