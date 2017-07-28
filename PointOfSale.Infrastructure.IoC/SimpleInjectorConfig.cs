using PointOfSale.Infrastructure.Repository.EF;
using PointOfSale.Infrastructure.Repository.Interfaces;
using PointOfSale.Infrastructure.Repository.Repositories;
using SimpleInjector;

namespace PointOfSale.Infrastructure.IoC
{
    public static class SimpleInjectorConfig
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register(typeof(IBaseRepository<>),
                                    new[] { typeof(BaseRepository<>).Assembly }, Lifestyle.Scoped);
            container.Register<PointOfSaleContext>(Lifestyle.Scoped);

            return container;
        }
    }
}
