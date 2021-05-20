using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesparasitacaoContext _context;

        public UnitOfWork(DesparasitacaoContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}