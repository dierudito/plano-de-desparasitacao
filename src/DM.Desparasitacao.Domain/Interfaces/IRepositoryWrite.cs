using System;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Interfaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        int SaveChanges();
    }
}