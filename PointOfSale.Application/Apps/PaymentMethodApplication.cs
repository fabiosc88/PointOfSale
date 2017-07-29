using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace PointOfSale.Application.Apps
{
    public class PaymentMethodApplication : ApplicationBase
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodApplication(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public PaymentMethodViewModel Get(Guid id)
        {
            return Mapper.Map<PaymentMethodViewModel>(_paymentMethodRepository.GetById(id));
        }

        public IEnumerable<PaymentMethodViewModel> List()
        {
            return Mapper.Map<IEnumerable<PaymentMethodViewModel>>(_paymentMethodRepository.GetAll());
        }

        public PaymentMethodViewModel Create(PaymentMethodViewModel vm)
        {
            var paymentMethod = Mapper.Map<PaymentMethod>(vm);

            var result = _paymentMethodRepository.Add(paymentMethod);

            return Mapper.Map<PaymentMethodViewModel>(result);
        }

        public bool Update(PaymentMethodViewModel vm, Guid id)
        {
            var paymentMethod = Mapper.Map<PaymentMethod>(vm);

            var result = _paymentMethodRepository.Update(paymentMethod, id);

            return result != null;
        }

        public bool Delete(Guid id)
        {
            var result = _paymentMethodRepository.Remove(id);

            return result;
        }
    }
}
