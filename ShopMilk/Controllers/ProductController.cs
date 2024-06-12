using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Reponsitory.IRepo;
using Service.Dto;
using Service.Interface;

namespace ShopMilk.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id) {
            _productService.Get(id);
            if (_productService.Flag)
            {
                if(null == _productService.ObjDetail)
                {
                    return NotFound();
                }
                return Ok(_productService.ObjDetail);
            }
            else
            {
                return BadRequest(_productService.Error);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            _productService.GetAll();
            if(_productService.Flag)
            {
                return Ok(_productService.ObjList);
            }
            else
            {
                return BadRequest(_productService.Error);
            }
        }
        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public IActionResult Create([FromForm] ProductDto entity, IList<IFormFile> listFile)
        //{
        //    //if(listFile.Count == 0)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    //_productService.Create(entity, listFile);
        //    var product = _mapper.Map<Product>(entity);
        //    _productService.Create(product);
        //    if (_productService.Flag)
        //    {
        //        return CreatedAtAction(nameof(Get), new { id = entity.ProdId }, entity);
        //    }
        //    else
        //    {
        //        return BadRequest(_productService.Error);
        //    }
        //}
        [HttpPost]
        [Authorize(Roles = "Admin")] // Endpoint is Admi
        public IActionResult Create([FromForm] Product entity)
        {
            Category cate = new Category();
            var product = new Product {
                ProdId = entity.ProdId,
                ProdImageUrl = entity.ProdImageUrl,
                ProdDescription = entity.ProdDescription,
                CateId = entity.CateId,
                ProdTitle = entity.ProdTitle,
                ProdPrice = entity.ProdPrice
            };
            _productService.Create(product);
            if(_productService.Flag)
            {
                return CreatedAtAction(nameof(Get), new { id = product.ProdId, product.CateId }, product);
            }
            else
            {
                return BadRequest(_productService.Error);
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromForm] Product entity)
        {
            Product product = new Product()
            {
                ProdId = entity.ProdId,
                ProdTitle = entity.ProdTitle,
                ProdDescription = entity.ProdDescription,
                ProdImageUrl = entity.ProdImageUrl,
                ProdPrice = entity.ProdPrice,
                CateId = entity.CateId
            };
            _productService.Update(product);
            if(_productService.Flag)
            {
                _productService.Get(entity.ProdId);
                return Ok(_productService.ObjDetail);
            }
            else
            {
                return BadRequest(_productService.Error);
            }
        }
        [HttpPost]
        public  IActionResult Delete([FromForm]string prodIdFormat)
        {
            try
            {
                _productService.Delete(prodIdFormat);
                if (_productService.Flag)
                {
                    return Ok("Product delete succesfuly");
                }
                return Ok(_productService.ObjDetail);
            }catch(Exception ex)
            {
                return BadRequest(_productService.Error);
            }
        }

    }
}