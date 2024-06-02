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
    public class CartDetailController : BaseController<CartDetail, CartDetailDto, ICartDetailRepo, ICartDetailService>
    {
        public CartDetailController(ICartDetailService _service) : base(_service)
        {
        }
        [HttpPost]
        public override IActionResult Create([FromForm] CartDetail entity)
        {
            if (entity == null)
            {
                return BadRequest("Not oke");
            }
            try
            {
                //_Service.AddCartDetail(entity);
                if (_Service.Flag)
                {
                    return CreatedAtAction(nameof(Get), new { id = entity.CaId},entity);
                }
                else
                {
                    return BadRequest(_Service.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(_Service.Error);
            }
        }
    }
}
