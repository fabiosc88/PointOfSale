using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
