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
        public UsersController(IUserService _service) : base(_service)
        {
        }
    }
}