using System.Collections.Generic;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.Repository
{
    public class ProtocoloLuaRepository : Repository<ProtocoloLua>, IProtocoloLuaRepository
    {
        public ProtocoloLuaRepository(DesparasitacaoContext context) : base(context)
        {
        }

        public IEnumerable<ProtocoloLua> ObterPorLua(Lua lua)
        {
            return Buscar(p => p.Lua == lua);
        }
    }
}