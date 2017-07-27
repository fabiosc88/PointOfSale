namespace PointOfSale.Infrastructure.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
