using Model.Model;
using Reponsitory.IRepo;
using Reponsitory.Repo;
using Service.Base;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderService : IBaseService<Order,OrderDto,IOrderRepo>
    {
    }
}