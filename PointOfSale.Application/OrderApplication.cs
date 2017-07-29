using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;

namespace PointOfSale.Application
{
    public class OrderApplication : ApplicationBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApplication(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderViewModel Get(int id)
        {
            return Mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public IEnumerable<OrderViewModel> List()
        {
            return Mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetAll());
        }

        public bool Update(OrderViewModel vm, int id)
        {
            var order = Mapper.Map<Order>(vm);

            BeginTransaction();
            var result = _orderRepository.Update(order, id);
            Commit();

            return result != null;
        }

        public bool Delete(int id)
        {
            BeginTransaction();
            var result = _orderRepository.Remove(id);
            Commit();

            return result;
        }
    }
}
