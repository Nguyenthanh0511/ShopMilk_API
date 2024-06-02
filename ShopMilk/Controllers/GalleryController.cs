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
    public class GalleryController : BaseController<Gallery, GalleryDto, IGalleryRepo, IGalleryService>
    {
        public GalleryController(IGalleryService _service) : base(_service)
        {
        }
        //[HttpPost]
        //public override IActionResult Create([FromForm]Gallery gallery)
        //{
        //    this._Service.ObjDetail.GId = 1;
        //    this._Service.ObjDetail.GThumbnail = "123a";
        //    this._Service.ObjDetail.ProdId = 2;
        //    if(_Service.ObjDetail.GId != 0)
        //    {
        //        _Service.Create(_Service.ObjDetail);
        //    }
        //    else
        //    {
        //        Console.WriteLine("fALSE");
        //    }
        //    return Ok("");
        //}
    }
}
