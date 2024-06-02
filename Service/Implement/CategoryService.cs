using AutoMapper;
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

namespace Service.Implement
{
    public class CategoryService : BaseService<Category, CategoryDto, ICategoryRepo>, ICategoryService
    {
        public CategoryService(ICategoryRepo trepo, IMapper _map) : base(trepo, _map)
        {
        }
    }
}
