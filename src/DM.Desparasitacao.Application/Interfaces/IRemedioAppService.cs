using System;
using System.Collections.Generic;
using DM.Desparasitacao.Application.ViewModels;

namespace DM.Desparasitacao.Application.Interfaces
{
    public interface IRemedioAppService : IDisposable
    {
        RemedioViewModel ObterPorId(Guid id);
        IEnumerable<RemedioViewModel> ObterTodos();
        RemedioViewModel Adicionar(RemedioViewModel remedioViewModel);
        RemedioViewModel Atualizar(RemedioViewModel remedioViewModel);
        void Remover(Guid id);
    }
}