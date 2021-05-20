using System;
using DM.Desparasitacao.Application.ViewModels;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Application.Interfaces
{
    public interface IFaseDaLuaAppService : IDisposable
    {
        FaseDaLuaViewModel ObterPorId(Guid id);
        FaseDaLuaViewModel Adicionar(FaseDaLuaViewModel faseDaLua);
    }
}