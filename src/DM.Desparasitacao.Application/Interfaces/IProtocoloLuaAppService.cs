using System;
using System.Collections.Generic;
using DM.Desparasitacao.Application.ViewModels;

namespace DM.Desparasitacao.Application.Interfaces
{
    public interface IProtocoloLuaAppService : IDisposable
    {
        ProtocoloLuaTratamentoViewModel Adicionar(ProtocoloLuaTratamentoViewModel protocoloLuaTratamentoViewModel);
        ProtocoloLuaViewModel ObterPorId(Guid id);
        int ObterProximoNumeroDaLua(LuaViewModel lua);
        IEnumerable<ProtocoloLuaViewModel> ObterTodos();
        IEnumerable<ProtocoloLuaViewModel> ObterPorLua(LuaViewModel lua);
        ProtocoloLuaViewModel Atualizar(ProtocoloLuaViewModel protocoloLuaViewModel);
        void Remover(Guid id);
    }
}