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
    public class GalleryService : BaseService<Gallery, GalleryDto, IGalleryRepo>, IGalleryService
    {
        public GalleryService(IGalleryRepo trepo, IMapper _map) : base(trepo, _map)
        {
        }
    }
}
