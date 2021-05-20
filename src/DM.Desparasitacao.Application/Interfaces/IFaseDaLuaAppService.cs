using System;
using System.Collections.Generic;
using DM.Desparasitacao.Application.ViewModels;

namespace DM.Desparasitacao.Application.Interfaces
{
    public interface IFaseDaLuaAppService : IDisposable
    {
        FaseDaLuaViewModel ObterPorId(Guid id);
        IEnumerable<FaseDaLuaViewModel> ObterTodos();
        FaseDaLuaViewModel Adicionar(FaseDaLuaViewModel faseDaLuaViewModel);
        FaseDaLuaViewModel Atualizar(FaseDaLuaViewModel faseDaLuaViewModel);
        void Remover(Guid id);
    }
}