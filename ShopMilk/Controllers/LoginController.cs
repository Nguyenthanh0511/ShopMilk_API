using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Service.Interface;
using ShopMilk.HelperAuthen;

namespace ShopMilk.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController:Controller
    {
        private readonly IUserService userService;

        public LoginController(IUserService u)
        {
            userService = u;
        }
        [HttpPost(Name ="Login")]
        public IActionResult Login([FromForm] User user)
        {
            var entity = new User
            {
                UUserName = user.UUserName,
                UPassword = user.UPassword
            };
            entity.UPassword = JWTAuthen.hashPassword(entity.UPassword);
            userService.LoginUser(entity);
            if (userService.Flag)
            {
                if (null == userService.ObjDetail)
                {
                    return NotFound("Vui lòng nhập đúng tài khoản hoặc mật khẩu tài khoản!");
                }
                else
                {
                    //is correct and then create token of user
                    string token = JWTAuthen.GenerateToke(userService.ObjDetail.UPassword, userService.ObjDetail.URole);
                    return Ok(token);
                }
            }
            else
            {
                return BadRequest(userService.Error);
            }
        }
        [HttpPost]
        public IActionResult Register([FromForm]User user) {
            user.UPassword = JWTAuthen.hashPassword(user.UPassword); // My password is short in the database, have to change contraint in a table.
            user.URole = "Admin";
            user.UId = Guid.NewGuid().ToString().Substring(1,15);
            userService.Create(user);
            if (userService.Flag)
            {
                return Ok(userService.ObjDetail);
            }
            else
            {
                return BadRequest(userService.Error);
            }
        }
        
    }
}
