using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace PointOfSale.Application.Apps
{
    public class CategoryApplication : ApplicationBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryViewModel Get(Guid id)
        {
            return Mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
        }

        public IEnumerable<CategoryViewModel> List()
        {
            return Mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAll());
        }

        public CategoryViewModel Create(CategoryViewModel vm)
        {
            var category = Mapper.Map<Category>(vm);

            var result = _categoryRepository.Add(category);

            return Mapper.Map<CategoryViewModel>(result);
        }

        public bool Update(CategoryViewModel vm, Guid id)
        {
            var category = Mapper.Map<Category>(vm);


            var result = _categoryRepository.Update(category, id);

            return result != null;
        }

        public bool Delete(Guid id)
        {
            var result = _categoryRepository.Remove(id);

            return result;
        }
    }
}
