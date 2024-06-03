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
    public interface ICartDetailService<c> where c : CartDetail
    {
        bool Flag { get; set; }
        string Error { get; set; }
        CartDetail ObjectDetail { get; set; }
        List<CartDetail> ObjList { get; set; }
        public void addcartdetail(string UserId,string productid,int quantity);
        public void removecartdetail(string UserId, string productid, int quantity);
        public void getAllCartDetail(string UserId);
    }
}
