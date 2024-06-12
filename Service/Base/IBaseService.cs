using Reponsitory.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Service.Base
{
    public interface IBaseService<T, TDto, TRepo> 
        where T : class 
        where TDto : class 
        where TRepo : IBaseRepo<T>
    {
        T? ObjDetail { get; set; }
        List<T> ObjList { get; set; }
        TDto ObjDetailDto { get; set; }
        List<TDto> ObjListDto { get; set; }
        bool Flag { get; set; }
        string Error { get; set; }
        void Get(string id);
        void GetDto(string id);
        List<T> GetAll();
        void GetAllDto();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(string id);
    }
}


