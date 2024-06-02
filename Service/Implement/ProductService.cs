using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Model;
using Reponsitory.IRepo;
using Service.Base;
using Service.Dto;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Helper;

namespace Service.Implement
{
    public class ProductService : BaseService<Product, ProductDto, IProductRepo>, IProductService
    {
        public readonly IGalleryService _galleryService;
        public readonly IProductRepo _productRepo;
        public ProductService(IProductRepo trepo, IMapper _map,IGalleryService _G) : base(trepo, _map)
        {
            this._galleryService = _G;
            this._productRepo = trepo;
        }
        public void Create(Product product, IList<IFormFile> listFile)
        {
            try
            {
                product.ProdImageUrl = Guid.NewGuid().ToString();
                base.Create(product);
                foreach(var item in listFile)
                {
                    string path = ServiceImage.CreateImage(item);
                    if(!string.IsNullOrEmpty(path))
                    {
                        var image = new Gallery
                        {
                            GThumbnail = Guid.NewGuid().ToString(),
                            //GThumbnail = path // Lưu trữ đường dẫn URL của hình ảnh
                        };
                        _galleryService.Create(image);
                    }
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public void Update(Product entity, IList<IFormFile> listFile, List<Gallery> listFileDelete)
        {
            try
            {
                base.Update(entity);
                foreach (var item in listFileDelete)
                {
                    _galleryService.Delete(item);
                }
                foreach(var item in listFile)
                {
                    string path = ServiceImage.CreateImage(item);
                    if (!string.IsNullOrEmpty(path))
                    {
                        var gallery = new Gallery();
                        gallery.GThumbnail = path;
                        _galleryService.Create(gallery);
                    }
                }
            }catch(Exception ex)
            {
                Error = ex.Message; Flag = false;
            }
        }
    }
}
