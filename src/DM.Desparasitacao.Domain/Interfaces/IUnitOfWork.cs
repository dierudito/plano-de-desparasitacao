namespace DM.Desparasitacao.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void BeginTransaction();
        void Rollback();
        bool SaveChanges();
    }
}