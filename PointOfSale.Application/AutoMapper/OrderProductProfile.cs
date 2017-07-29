using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.AutoMapper
{
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, OrderProductViewModel>().ReverseMap();
        }
    }
}
