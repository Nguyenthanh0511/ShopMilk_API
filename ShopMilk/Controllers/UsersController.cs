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
    public class UsersController : BaseController<User,UserDto,IUserRepo,IUserService>
    {
        private readonly Shopmilk_5Context _context;
        public UsersController(IUserService _service, Shopmilk_5Context context) : base(_service)
        {
            _context = context; 
        }
        [HttpGet("{UserName}")]
        public IActionResult retrunFllowId(string UserName)
        {
            if(UserName == null)
            {
                return BadRequest("User Null");
            }
            else
            {
                var userId = _context.Users.Where(u => u.UUserName == UserName).Select(u => u.UId).FirstOrDefault();
                return Ok(userId);
            }
        }

    }
}