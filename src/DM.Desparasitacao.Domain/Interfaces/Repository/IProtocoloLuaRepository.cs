using System.Collections.Generic;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Interfaces.Repository
{
    public interface IProtocoloLuaRepository : IRepositoryRead<ProtocoloLua>, IRepositoryWrite<ProtocoloLua>
    {
        IEnumerable<ProtocoloLua> ObterPorLua(Lua lua);
    }
}