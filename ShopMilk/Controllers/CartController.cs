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
    }
}