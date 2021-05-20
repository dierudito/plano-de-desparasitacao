using System;
using System.Linq;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.Repository
{
    public class FaseDaLuaRepository : Repository<FaseDaLua>, IFaseDaLuaRepository
    {
        public FaseDaLuaRepository(DesparasitacaoContext context) : base(context)
        {
        }

        public FaseDaLua ObterPorDataOcorrencia(DateTime dataOcorrencia)
        {
            return Buscar(f => f.DataOcorrencia == dataOcorrencia).FirstOrDefault();
        }
    }
}