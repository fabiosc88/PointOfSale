using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace PointOfSale.Application.Apps
{
    public class ProductApplication : ApplicationBase
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductViewModel Get(Guid id)
        {
            return Mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public IEnumerable<ProductViewModel> List()
        {
            return Mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public ProductViewModel Create(ProductViewModel vm)
        {
            var product = Mapper.Map<Product>(vm);

            var result = _productRepository.Add(product);

            return Mapper.Map<ProductViewModel>(result);
        }

        public bool Update(ProductViewModel vm, Guid id)
        {
            var product = Mapper.Map<Product>(vm);

            var result = _productRepository.Update(product, id);

            return result != null;
        }

        public bool Delete(Guid id)
        {
            var result = _productRepository.Remove(id);

            return result;
        }

        public IEnumerable<ProductViewModel> GetMany(List<Guid> items)
        {
            return Mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetMany(items));
        }
    }
}
