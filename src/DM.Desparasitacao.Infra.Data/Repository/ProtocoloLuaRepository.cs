using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.Repository
{
    public class ProtocoloLuaRepository : Repository<ProtocoloLua>, IProtocoloLuaRepository
    {
        public ProtocoloLuaRepository(DesparasitacaoContext context) : base(context)
        {
        }
    }
}