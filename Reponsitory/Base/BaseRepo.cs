using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Base
{
    public class BaseRepo<T> : IBaseRepo<T> 
                 where T : class, new()
    {
        private readonly Shopmilk_5Context _context;
        //public DbSet<T> _dbSet { get; set; }

        public BaseRepo(Shopmilk_5Context shop)
        {
            _context = shop;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public virtual T? Get(string id)
        {
            return _context.Set<T>().Find(id);
        }
        public virtual void Create(T entity)
        {
            if(entity != null)
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Khong co entity");
            }
        }
        public void Create(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity); 
            _context.SaveChanges();
        }
        public virtual void Delete(int id)
        {
            T entity = _context.Set<T>().Find(id);
            // Nếu id của entity.id bằng với bảng có khóa ngoại thì xóa cả bảng trường dữ liệu đấy
            if(entity == null)
            {
                throw new Exception($"Entity with id: {id} not found");
            }
            //Lấy tất cả danh sách entity đó
            
            //_context.Entry(entity).Collection(e => e.RelatedEntities).Load();
            //_context.Entry(entity).Collection(e => e.)
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity) ;
            _context.SaveChanges();
        }
        public void Delete(List<int> entities)
        {
            foreach(var item in entities)
            {
                Delete(item);
            }
            _context.SaveChanges();
        }
        public virtual void Delete(List<T> listEntity)
        {
            foreach (var item in listEntity)
            {
                Delete(item);
            }
        }
    }
}
