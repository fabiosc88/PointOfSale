using AutoMapper;
using PointOfSale.Application.ViewModels;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;

namespace PointOfSale.Application
{
    public class PaymentMethodApplication : ApplicationBase
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodApplication(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public PaymentMethodViewModel Get(int id)
        {
            return Mapper.Map<PaymentMethodViewModel>(_paymentMethodRepository.GetById(id));
        }

        public IEnumerable<PaymentMethodViewModel> List()
        {
            return Mapper.Map<IEnumerable<PaymentMethodViewModel>>(_paymentMethodRepository.GetAll());
        }

        public bool Update(PaymentMethodViewModel vm, int id)
        {
            var paymentMethod = Mapper.Map<PaymentMethod>(vm);

            BeginTransaction();
            var result = _paymentMethodRepository.Update(paymentMethod, id);
            Commit();

            return result != null;
        }

        public bool Delete(int id)
        {
            BeginTransaction();
            var result = _paymentMethodRepository.Remove(id);
            Commit();

            return result;
        }
    }
}
