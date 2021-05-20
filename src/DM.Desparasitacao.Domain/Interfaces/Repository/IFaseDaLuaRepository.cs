using System;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Interfaces.Repository
{
    public interface IFaseDaLuaRepository : IRepositoryRead<FaseDaLua>, IRepositoryWrite<FaseDaLua>
    {
        FaseDaLua ObterPorDataOcorrencia(DateTime dataOcorrencia);

    }
}