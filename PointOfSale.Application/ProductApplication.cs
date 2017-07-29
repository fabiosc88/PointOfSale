using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;

namespace PointOfSale.Application
{
    public class ProductApplication : ApplicationBase
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductViewModel Get(int id)
        {
            return Mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public IEnumerable<ProductViewModel> List()
        {
            return Mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public bool Update(ProductViewModel vm, int id)
        {
            var product = Mapper.Map<Product>(vm);

            BeginTransaction();
            var result = _productRepository.Update(product, id);
            Commit();

            return result != null;
        }

        public bool Delete(int id)
        {
            BeginTransaction();
            var result = _productRepository.Remove(id);
            Commit();

            return result;
        }
    }
}
