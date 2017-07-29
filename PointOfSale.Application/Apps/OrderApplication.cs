using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace PointOfSale.Application.Apps
{
    public class OrderApplication : ApplicationBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApplication(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderViewModel Get(Guid id)
        {
            return Mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public IEnumerable<OrderViewModel> List()
        {
            return Mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetAll());
        }

        public bool Update(OrderViewModel vm, Guid id)
        {
            var order = Mapper.Map<Order>(vm);
            
            var result = _orderRepository.Update(order, id);

            return result != null;
        }

        public bool Delete(Guid id)
        {
            var result = _orderRepository.Remove(id);

            return result;
        }
    }
}
