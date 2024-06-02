using AutoMapper;
using Model.Model;
using Reponsitory.IRepo;
using Reponsitory.Repo;
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
    public class OrderService : BaseService<Order,OrderDto,IOrderRepo>,IOrderService
    {
        public IProductRepo _productRepo;
        public OrderService(IOrderRepo trepo, IMapper _map ,IProductRepo product) : base(trepo, _map)
        {
            _productRepo = product;
        }

        public override void Create(Order order)
        {
            try
            {
                order.OrDate = DateTime.Now;
                foreach(var orderDetail in order.OrdersDetails)
                {
                    orderDetail.OrId = order.OrId;
                    var product = _productRepo.Get(orderDetail.ProdId);
                    orderDetail.ProdPrice = product.ProdPrice;
                    _productRepo.Update(product);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
    }
}
