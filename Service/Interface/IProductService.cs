using Model.Model;
using Reponsitory.IRepo;
using Service.Base;
using Service.Dto;
using Microsoft.AspNetCore.Http;

namespace Service.Interface
{
    public interface IProductService : IBaseService<Product,ProductDto,IProductRepo>
    {
        public void Create(Product entity, IList<IFormFile> listFile);
        public void Update(Product entity,IList<IFormFile> listFile,List<Gallery> listFileDelete);
    }
}