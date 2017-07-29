using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.AutoMapper
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethod, PaymentMethodViewModel>().ReverseMap();
        }
    }
}
