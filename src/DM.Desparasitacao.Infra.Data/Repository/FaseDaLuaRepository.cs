using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.Repository
{
    public class FaseDaLuaRepository : Repository<FaseDaLua>, IFaseDaLuaRepository
    {
        public FaseDaLuaRepository(DesparasitacaoContext context) : base(context)
        {
        }
    }
}