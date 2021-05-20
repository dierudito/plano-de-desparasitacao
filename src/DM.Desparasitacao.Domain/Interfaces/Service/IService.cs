using System;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Interfaces.Service
{
    public interface IService<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar(TEntity entity);
        TEntity Atualizar(TEntity entity);
        void Remover(Guid id);
    }
}