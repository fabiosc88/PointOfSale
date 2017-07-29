using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;

namespace PointOfSale.Application
{
    public class CategoryApplication : ApplicationBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryViewModel Get(int id)
        {
            return Mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
        }

        public IEnumerable<CategoryViewModel> List()
        {
            return Mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAll());
        }

        public bool Update(CategoryViewModel vm, int id)
        {
            var category = Mapper.Map<Category>(vm);

            BeginTransaction();
            var result = _categoryRepository.Update(category, id);
            Commit();

            return result != null;
        }

        public bool Delete(int id)
        {
            BeginTransaction();
            var result = _categoryRepository.Remove(id);
            Commit();

            return result;
        }
    }
}
