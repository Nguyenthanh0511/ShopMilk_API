using AutoMapper;
using Model.Model;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MappingP : Profile
    {
        public MappingP() { 
            CreateMap<Product, ProductDto>()
               .ForMember(dest => dest.ProdId, opt => opt.MapFrom(src => src.ProdId))
               .ReverseMap();
            CreateMap<Gallery, GalleryDto>()
                .ForMember(dest => dest.GId, opt => opt.MapFrom(src => src.GId))
                .ReverseMap();
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.CateId, opt => opt.MapFrom(src => src.CateId))
                .ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(u => u.username, opt => opt.MapFrom(src => src.UUserName)).ReverseMap();
        }
    }
}