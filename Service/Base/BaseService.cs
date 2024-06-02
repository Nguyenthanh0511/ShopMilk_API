using AutoMapper;
using Reponsitory.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public class BaseService<T,TDto,TRepo> : IBaseService<T, TDto, TRepo> where T : class,new() where TDto : class, new() where TRepo : IBaseRepo<T>

    {
        public virtual T? ObjDetail { get; set; }
        public List<T> ObjList { get; set; }
        public TDto ObjDetailDto { get; set; }
        public List<TDto> ObjListDto { get; set; }
        public bool Flag { get; set; }
        public string Error { get; set; }
        public TRepo ThisRepo { get; set; }
        private readonly IMapper _mapper;

        public BaseService(TRepo trepo,IMapper _map)
        {
            ObjDetail = new T();
            ObjList = new List<T>();
            ObjDetailDto = new TDto();
            ObjListDto = new List<TDto>();
            Flag = true;
            Error = "";
            ThisRepo = trepo;   
            _mapper = _map ?? throw new ArgumentNullException(nameof(_mapper));

        }
        public virtual void Create(T entity)
        {
            try
            {
                ThisRepo.Create(entity);
            }catch(Exception ex)
            {
                Error = ex.Message;
                Flag=false;
            }
            //throw new NotImplementedException();
        }
        public void Delete(T entity)
        {
            try
            {
                ThisRepo.Delete(entity);
            }catch( Exception ex) { Error = ex.Message; Flag=false; }
        }
        public void Delete(int id)
        {
            try
            {
                ThisRepo.Delete(id);

            }catch(Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public void Get(string id)
        {
            try
            {
                this.ObjDetail = ThisRepo.Get(id);
            }catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                this.ObjList = ThisRepo.GetAll();
                return (ThisRepo.GetAll());
            }
            catch(Exception ex)
            {
                Error = ex.Message;
                Flag = false;
                return null;
            }
        }

        public void GetAllDto()
        {
            try
            {
                var v = ThisRepo.GetAll();

                //var t=_mapper.Map<IList<T>>(v);
                this.ObjListDto = _mapper.Map<List<TDto>>(v);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public void GetDto(string id)
        {
            try
            {
                this.ObjDetailDto = _mapper.Map<TDto>(ThisRepo.Get(id));
            }catch(Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public void Update(T entity)
        {
            try
            {
                ThisRepo.Update(entity);
            }catch(Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        
    }
}
