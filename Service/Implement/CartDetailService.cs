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
    public class CartDetailService : BaseService<CartDetail, CartDetailDto, ICartDetailRepo>,ICartDetailService
    {
        public CartDetailService(ICartDetailRepo trepo, IMapper _map) : base(trepo, _map)
        {
        }
        //    public void AddCartDetail(CartDetail cartdetail)
        //    {
        //        // Idea: Give carid and prodid ( objdetail )
        //        try
        //        {
        //            this.ObjDetail = this.ThisRepo._contex.FirstOrDefault(x => x.ProdId == cartdetail.ProdId && x.CaId == cartdetail.CaId);
        //            if(this.ObjDetail != null ) {
        //                this.ObjDetail.Quantity += cartdetail.Quantity;
        //                ThisRepo.Update(this.ObjDetail);
        //            }
        //            else
        //            {
        //                ThisRepo.Create(cartdetail);
        //            }
        //        }catch(Exception ex)
        //        {
        //            Error = ex.Message;
        //            Flag = false;
        //        }
        //    }


    }
}
