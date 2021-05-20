using System;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Interfaces.Repository
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        int SaveChanges();
    }
}