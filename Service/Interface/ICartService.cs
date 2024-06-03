using Model.Model;
using Reponsitory.IRepo;
using Service.Base;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICartService:IBaseService<Cart,CartDto,ICartRepo>
    {
        //public void AddToCart(string UserId, string ProductId,int quantity);
        //public void RemoveToCart(string CartId, string ProductId);
        //public void GetAllCart();
    }
}