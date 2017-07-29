using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
