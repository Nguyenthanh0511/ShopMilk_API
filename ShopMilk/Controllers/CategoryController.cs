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
    public class CategoryController: BaseController<Category,CategoryDto,ICategoryRepo,ICategoryService> 
    {
        public CategoryController(ICategoryService categoryService) : base(categoryService)
        {
        }
    }
}
