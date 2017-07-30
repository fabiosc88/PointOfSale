using PointOfSale.Infrastructure.Repository.EF;
using PointOfSale.Infrastructure.Repository.Interfaces;
using PointOfSale.Infrastructure.Repository.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Lifestyles;

namespace PointOfSale.Infrastructure.IoC
{
    public static class SimpleInjectorConfig
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
           /* container.Register(typeof(IBaseRepository<>),
                                    new[] { typeof(BaseRepository<>).Assembly }, Lifestyle.Scoped);*/

            container.Register<IProductRepository, ProductRepository>();
            container.Register<ICategoryRepository, CategoryRepository>();
            container.Register<IPaymentMethodRepository, PaymentMethodRepository>();
            container.Register<PointOfSaleContext>(Lifestyle.Scoped);

            return container;
        }
    }
}
