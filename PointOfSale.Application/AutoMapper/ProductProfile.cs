using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
