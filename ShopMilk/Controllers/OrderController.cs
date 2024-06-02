using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Reponsitory.IRepo;
using Reponsitory.Repo;
using Service.Dto;
using Service.Interface;
using ShopMilk.Controllers.NewFolder;

namespace ShopMilk.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class OrderController : BaseController<Order,OrderDto,IOrderRepo,IOrderService>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService _service) : base(_service)
        {
        }
        public override IActionResult Create(Order order)
        {
            if (HttpContext.Items["UserId"] == null)
            {
                return BadRequest();
            }
            string UserId;
            try
            {
                UserId = HttpContext.Items["UserId"].ToString();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            order.UId = UserId;
            return base.Create(order);
        }
    }
}
