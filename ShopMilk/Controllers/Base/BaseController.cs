using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reponsitory.Base;
using Service.Base;

namespace ShopMilk.Controllers.NewFolder
{
    public class BaseController<T, TDto, TRepo, TService> : Controller where T : class where TDto : class where TRepo : IBaseRepo<T> where TService : IBaseService<T, TDto, TRepo>
    {
        public readonly TService _Service;
        public BaseController(TService _service)
        {
            _Service = _service??throw new ArgumentNullException(nameof(_Service));
        }
        [HttpGet("{id}")]
        public virtual IActionResult Get(string id)
        {
            _Service.Get(id);
            if (_Service.Flag)
            {
                if (_Service.ObjDetail == null)
                {
                    return NotFound();
                }
                return Ok(_Service.ObjDetail);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public virtual IActionResult GetAll() {
            var listObject = _Service.GetAll();
            if (_Service.Flag)
            {
                return Ok(listObject);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public virtual IActionResult GetDtoAll()
        {
            _Service.GetAllDto();
            if (_Service.Flag)
                return Ok(_Service.ObjListDto);
            else
                return BadRequest();
        }

        [HttpPost]
        public virtual IActionResult Create([FromBody]T entity)
        {
            _Service.Create(entity);
            if (_Service.Flag)
            {
                return Ok(_Service.ObjDetail);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpPut]
        public virtual IActionResult Update([FromForm]T entity)
        {
            _Service.Update(entity);
            if( _Service.Flag)
            {
                return Ok(_Service.ObjDetail);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpPost]
        public virtual IActionResult Delete(int id)
        {
            _Service.Delete(id);
            if (_Service.Flag)
            {
                return Ok("Delete succesfully");
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
    }
}
